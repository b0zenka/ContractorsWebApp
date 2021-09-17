using AutoMapper;
using ContratorsWebAPI.Entities;
using ContratorsWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContratorsWebAPI
{
    public class ContractotsMappingProfile : Profile
    {
        public ContractotsMappingProfile()
        {
            CreateMap<Contractor, ContractorDto>()
                .ForMember(cd => cd.Country, c => c.MapFrom(s => s.Address.Country))
                .ForMember(cd => cd.City, c => c.MapFrom(s => s.Address.City))
                .ForMember(cd => cd.Street, c => c.MapFrom(s => s.Address.Street))
                .ForMember(cd => cd.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));

            CreateMap<ContractorDto, Contractor>()
                .ForMember(c => c.Address, cr => cr.MapFrom(dto => 
                new Address()
                {
                    Country = dto.Country,
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode
                }));
        }
    }
}
