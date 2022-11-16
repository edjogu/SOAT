using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Entities
{
    public class City
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string CityName { get; set; }

        [Required]
        public bool IsForSOAT { get; set; }
        
    }
}
