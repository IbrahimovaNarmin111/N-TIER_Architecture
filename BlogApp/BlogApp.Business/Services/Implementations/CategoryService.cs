using BlogApp.Business.DTOs.CategoryDTO;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
            var categories=await _repository.GetAllAsync();
            return await categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
           return await _repository.GetByIdAsync(id);   
        }
        public async Task<Category> Create(CreateCategoryDto categorydto)
        {
            if (categorydto == null) throw new Exception();
            Category category = new Category()
            {
                Name = categorydto.Name,
                LogoUrl=categorydto.LogoUrl,
                Image=categorydto.Image,
            };

            await _repository.Create(category);
            await _repository.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(int id, UpdateCategoryDto categorydto)
        {
            if (categorydto == null) throw new Exception();
            var categories = await _repository.GetByIdAsync(id);
            if (categories == null) throw new Exception();
            categories.Name = categorydto.Name;
            categories.LogoUrl = categorydto.LogoUrl;
            categories.Image = categorydto.Image;
            _repository.Update(categories);
            await _repository.SaveChangesAsync();
            return categories;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var categories = await _repository.GetByIdAsync(id);
            if (categories == null) throw new Exception();
            _repository.Delete(categories);
            await _repository.SaveChangesAsync();
            return categories;
        }
    }
}
