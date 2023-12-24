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
        Task<ICollection<Category>> GetAllAsync();
        Task<Category>GetByIdAsync(int id);
        Task<Category> Create(CreateCategoryDto categorydto);
        Task<Category> Update(int id, UpdateCategoryDto categorydto);
        Task<Category> DeleteAsync(int id);
    }
}
