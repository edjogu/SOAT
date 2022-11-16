using SOATSales.API.Entities;
using System;
using System.Collections.Generic;

namespace SOATSales.API.Services
{
    public interface ISOATSalesRepository
    {    
        void AddPolicy(Guid cityId, Policy policy);
        void AddCity(City city);
        Policy GetPolicy(string licencePlate);
        IEnumerable<Policy> GetPolicies();
        bool CityExistsAndIsAllowed(Guid cityId);
        bool Save();
    }
}
