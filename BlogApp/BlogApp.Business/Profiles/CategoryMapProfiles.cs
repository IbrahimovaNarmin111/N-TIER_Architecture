using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTO;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Profiles
{
    public class CategoryMapProfiles:Profile
    {
        public CategoryMapProfiles() 
        {
            CreateMap<Category, CategoryListItemDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
        }
    }
}
