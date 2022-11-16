using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Models
{
    public class PolicyForCreationDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PolicyNumber { get; set; }

        public DateTimeOffset DateOfIssue { get; set; }

        public DateTimeOffset DateOfStart { get; set; }

        public DateTimeOffset DateOfExpiration { get; set; }

        public string LicencePlate { get; set; }        
    }
}
