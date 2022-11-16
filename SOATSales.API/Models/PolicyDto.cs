using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Models
{
    public class PolicyDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PolicyNumber { get; set; }

        public DateTimeOffset DateOfIssue { get; set; }

        public DateTimeOffset DateOfStart { get; set; }

        public DateTimeOffset DateOfExpiration { get; set; }

        public string LicencePlate { get; set; }

        public Guid CityId { get; set; }
    }
}
