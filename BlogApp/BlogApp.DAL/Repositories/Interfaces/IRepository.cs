using BlogApp.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T :BaseEntity,new()
    {
        DbSet<T> table { get; }
        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderbyExpression = null, bool isDesting = false, params string[]? includes);
        Task<T> GetByIdAsync(int id, params string[]? includes);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveChangesAsync();
    }
}
