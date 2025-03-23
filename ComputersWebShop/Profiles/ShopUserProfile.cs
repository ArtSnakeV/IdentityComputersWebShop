using AutoMapper;
using ComputersWebShop.Data;
using ComputersWebShop.Models.DTOs.Users;

namespace ComputersWebShop.Profiles
{
    public class ShopUserProfile : Profile
    {
        public ShopUserProfile()
        {
            CreateMap<ShopUser, ShopUserDTO>().ReverseMap();

        }
    }
}
