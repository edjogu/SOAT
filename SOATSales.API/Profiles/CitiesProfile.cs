using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Profiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<Entities.City, Models.CityDto>();
        }
    }
}
