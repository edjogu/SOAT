using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Models
{
    public class CityDto
    {
        public Guid Id { get; set; }

        public string CityName { get; set; }

        public bool IsForSOAT { get; set; }        
    }
}
