using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SOATSales.API.Helpers;
using SOATSales.API.Models;
using SOATSales.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Controllers
{
    [ApiController]
    [Route("api/policies")]
    [Authorize]
    public class PoliciesController : ControllerBase
    {
        private readonly ISOATSalesRepository _soatSalesRepository;
        private readonly IMapper _mapper;

        public PoliciesController(ISOATSalesRepository soatSalesRepository,
            IMapper mapper)
        {
            _soatSalesRepository = soatSalesRepository ??
                throw new ArgumentNullException(nameof(soatSalesRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<PolicyDto>> GetPolicies()
        {
            var policiesFromRepo = _soatSalesRepository.GetPolicies();
            return Ok(_mapper.Map<IEnumerable<PolicyDto>>(policiesFromRepo));            
        }

        [HttpGet("{licencePlate}", Name = "GetPolicy")]
        public IActionResult GetPolicy(string licencePlate)
        {
            var policyFromRepo = _soatSalesRepository.GetPolicy(licencePlate);

            if (policyFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PolicyDto>(policyFromRepo));
        }

        [HttpPost("{cityId}/policies")]
        public ActionResult<PolicyDto> CreatePolicy(
            Guid cityId, PolicyForCreationDto policy)
        {
            if (!_soatSalesRepository.CityExistsAndIsAllowed(cityId))
            {
                return NotFound();
            }

            var validPeriod = policy.DateOfExpiration.GetCurrentDateForExpitation();

            if (validPeriod != 0)
            {
                return NotFound();
            }

            var policyEntity = _mapper.Map<Entities.Policy>(policy);
            _soatSalesRepository.AddPolicy(cityId, policyEntity);
            _soatSalesRepository.Save();

            var policyToReturn = _mapper.Map<PolicyDto>(policyEntity);
            return CreatedAtRoute("GetPolicy",
                new { licencePlate = policyToReturn.LicencePlate },
                policyToReturn);
        }
    }
}
