using AutoMapper;
using BlogApp.Business.DTOs.CategoryDTO;
using BlogApp.Business.Exceptions.Category;
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
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryListItemDto>> GetAllAsync()
        {
            IQueryable<Category> result=await _repository.GetAllAsync();    
            var categories=_mapper.Map<ICollection<CategoryListItemDto>>(result);
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            Category category=await _repository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");

            return category;
        }
        public async Task<bool> CreateAsync(CreateCategoryDto categorydto)
        {
            if (categorydto == null) throw new CategoryNotNullException();
            Category category = new Category();
            category.Name= categorydto.Name;
           

            await _repository.CreateAsync(category);
           var result= await _repository.SaveChangesAsync();
           if(result>0)
            {
                return true;
            }
            return false;
        }

        public async Task Update(int id, UpdateCategoryDto categorydto)
        {
            Category Category = await _repository.GetByIdAsync(id);
            if (Category == null) throw new Exception("Not Found");
            Category = _mapper.Map(categorydto, Category);
            _repository.Update(Category);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category Category = await _repository.GetByIdAsync(id);

            if (Category == null) throw new Exception("Category not found");

            _repository.Delete(Category);
            await _repository.SaveChangesAsync();
        }

        
    }
}
