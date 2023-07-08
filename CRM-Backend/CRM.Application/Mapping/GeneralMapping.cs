using AutoMapper;
using CRM.Application.Dtos;
using CRM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Position, PositionDto>().ReverseMap();

            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Sector, SectorDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
