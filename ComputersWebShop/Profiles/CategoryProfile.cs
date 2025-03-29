using AutoMapper;
using ComputersLibrary;
using ComputersWebShop.Models.DTOs.Categories;

namespace ComputersWebShop.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();
        }
    }
}
