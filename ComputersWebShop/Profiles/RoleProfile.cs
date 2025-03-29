using AutoMapper;
using ComputersWebShop.Models.DTOs.Roles;
using Microsoft.AspNetCore.Identity;

namespace ComputersWebShop.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<IdentityRole, RoleDTO>().ReverseMap();
        }
    }
}
