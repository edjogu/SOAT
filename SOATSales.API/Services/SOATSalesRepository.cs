using SOATSales.API.DbContexts;
using SOATSales.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOATSales.API.Services
{
    public class SOATSalesRepository : ISOATSalesRepository, IDisposable
    {
        private readonly SOATSalesContext _context;

        public SOATSalesRepository(SOATSalesContext context )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddPolicy(Guid cityId, Policy policy)
        {
            if (cityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cityId));
            }

            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }
            // always set the AuthorId to the passed-in authorId
            policy.CityId = cityId;
            _context.Policies.Add(policy); 
        }         

        public void AddCity(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException(nameof(city));
            }

            // the repository fills the id (instead of using identity columns)
            city.Id = Guid.NewGuid();
            _context.Cities.Add(city);
        }

        public Policy GetPolicy(string licencePlate)
        {
            if (licencePlate == string.Empty)
            {
                throw new ArgumentNullException(nameof(licencePlate));
            }

            return _context.Policies.FirstOrDefault(a => a.LicencePlate == licencePlate);
        }

        public IEnumerable<Policy> GetPolicies()
        {
            return _context.Policies.ToList<Policy>();
        }

        public bool CityExistsAndIsAllowed(Guid cityId)
        {
            if (cityId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(cityId));
            }

            return _context.Cities
              .Any(c => c.Id == cityId && c.IsForSOAT == true);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
               // dispose resources when needed
            }
        }
    }
}
