using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Profiles
{
    public class PoliciesProfile : Profile
    {
        public PoliciesProfile()
        {
            CreateMap<Entities.Policy, Models.PolicyDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Models.PolicyForCreationDto, Entities.Policy>();
        }
    }
}
