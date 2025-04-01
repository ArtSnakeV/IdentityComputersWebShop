using AutoMapper;
using ComputersLibrary;
using ComputersWebShop.Models.DTOs.ProductImages;

namespace ComputersWebShop.Profiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImage, ProductImageDTO>()
                .ReverseMap();
        }
    }
}
