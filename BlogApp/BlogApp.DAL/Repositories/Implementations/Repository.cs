using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _db;

        public Repository(AppDbContext db) 
        {
          _db = db;
        }
        public DbSet<T> table => _db.Set<T>();

        public async Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyExpression = null, bool isDesting = false, params string[]? includes)
        {
            IQueryable<T> query = table;
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            if (orderbyExpression != null)
            {
                query = isDesting ? query.OrderByDescending(orderbyExpression) : query.OrderBy(orderbyExpression);
            }
            return query.AsQueryable();
        }
        public async Task<T> GetByIdAsync(int id, params string[]? includes)
        {
            IQueryable<T> data = table;
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    data = data.Include(includes[i]);
                }
            }
            return await data.FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task CreateAsync(T entity)
        {
            await table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }
        public void Update(T entity)
        {
            table.Update(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _db.SaveChangesAsync();
        }
    }
}
