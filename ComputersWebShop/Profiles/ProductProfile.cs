using AutoMapper;
using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Products;

namespace ComputersWebShop.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>().
                ReverseMap();
        }
    }
}
