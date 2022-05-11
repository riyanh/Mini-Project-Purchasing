using AutoMapper;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;

namespace Purchasing.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //get 
            CreateMap<Vendor, VendorDto>();

            //post 
            CreateMap<VendorDto, Vendor>().ReverseMap();
        }
    }
}
