using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Entities
{
    public class Policy
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(14)]
        public string PolicyNumber { get; set; }

        [Required]
        public DateTimeOffset DateOfIssue { get; set; }

        [Required]
        public DateTimeOffset DateOfStart { get; set; }

        [Required]
        public DateTimeOffset DateOfExpiration { get; set; }

        [Required]
        [MaxLength(10)]
        public string LicencePlate { get; set; }

        [ForeignKey("CityId")]
        public City City { get; set; }

        public Guid CityId { get; set; }
    }
}
