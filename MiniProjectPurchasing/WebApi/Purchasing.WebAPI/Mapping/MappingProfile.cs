using AutoMapper;
using Purchasing.Entities.DTO;
using Purchasing.Entities.Models;

namespace Purchasing.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vendor, VendorDto>(); 
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<vPurchaseOrderVendor, vPurchaseOrderVendorDto>();
            CreateMap<vPurchaseOrderVendorDto, vPurchaseOrderVendor>().ReverseMap();
            CreateMap<vListPurchaseOrder, vListPurchaseOrderDto>();
            CreateMap<vListPurchaseOrderDto, vListPurchaseOrder>().ReverseMap();
            CreateMap<BusinessEntity, BusinessEntityDto>();
            CreateMap<BusinessEntityDto, BusinessEntityDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ShipMethod, ShipMethodDto>();
            CreateMap<ProductVendor, ProductVendorDto>();
            CreateMap<ProductVendorDto, ProductVendor>().ReverseMap();
            
        }
    }
}
