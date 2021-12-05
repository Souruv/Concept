using CF.ProjectService.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Application.Common.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool isDisableTracking = true);

        public U ExecuteScalar<U>(string query);
        public List<U> ExecuteReader<U>(string query);

        //DbContext GetDbContext();
        //IQueryable<T> GetAll(bool isAsNoTracking);
        //IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
        //IQueryable<T> SqlQuery(string query);
        //T GetSingle(Expression<Func<T, bool>> predicate);
        //T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        //void InsertIfNotExist(Expression<Func<T, Guid>> ids, List<T> entities);


        //void Delete(object id);


        //void DetachAllFromDbContext();
    }
}
