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
            CreateMap<VListVendor, VendorDto>();
            CreateMap<VProductReceipt, ProductReceiptDto>();

            //post 
            CreateMap<VendorDto, VListVendor>().ReverseMap();
            //CreateMap<ProductReceiptDto, VProductReceipt>().ReverseMap();
        }
    }
}
