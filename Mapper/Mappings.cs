using AutoMapper;
using ImplementationAssignment.Models;
using ImplementationAssignment.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationAssignment.Mapper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<SaleData, SaleDataDTO>().ReverseMap();
        }
    }
}
