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
    }
}
