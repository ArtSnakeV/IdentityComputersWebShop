using AutoMapper;
using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Brands;

namespace ComputersWebShop.Profiles
{
    public class BrandProfile : Profile
    {
        
        public BrandProfile()
        {
            CreateMap<Brand, BrandDTO>().
                ReverseMap();
        }
    }
}
