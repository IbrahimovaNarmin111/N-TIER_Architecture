using AutoMapper;
using BlogApp.Business.DTOs.UserDTO;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class UserMapperProfiles :Profile
    {
        public UserMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<RegisterDto, AppUser>().ReverseMap();

        }
    }
}
