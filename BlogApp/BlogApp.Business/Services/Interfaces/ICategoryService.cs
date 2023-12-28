using BlogApp.Business.DTOs.CategoryDTO;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryListItemDto>> GetAllAsync();
        Task<Category>GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCategoryDto categorydto);
        Task Update(int id, UpdateCategoryDto categorydto);
        Task DeleteAsync(int id);
         
    }
}
