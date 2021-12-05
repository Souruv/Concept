using CF.ProjectService.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CF.ProjectService.Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }
        public T Update(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Modified;
            return entity;
        }
        public void Delete(T entity)
        {
            _dbContext.Entry<T>(entity).State = EntityState.Deleted;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate,
                                            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (include != null)
            {
                query = include(query);
            }

            return await query.SingleOrDefaultAsync(predicate);
        }
        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null,
                                  Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                  bool isDisableTracking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (isDisableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }


        //public IQueryable<T> Filter(Expression<Func<T, bool>> predicate = null,
        //                          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //                          bool isDisableTracking = true)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();

        //    if (isDisableTracking)
        //    {
        //        query = query.AsNoTracking();
        //    }

        //    if (include != null)
        //    {
        //        query = include(query);
        //    }

        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }

        //    return query;
        //}

        public ApplicationDbContext GetDbContext()
        {
            return _dbContext;
        }

        public U ExecuteScalar<U>(string query)
        {
            U retulst = default(U);
            using (var command = this._dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = System.Data.CommandType.Text;
                //var parameter = new SqlParameter("@p1", ...);
                //command.Parameters.Add(parameter);

                this._dbContext.Database.OpenConnection();
                var tempResult = command.ExecuteScalar();
                if (tempResult != null && !tempResult.Equals(DBNull.Value))
                {
                    retulst = (U)tempResult;

                }

                //using (var result =<T> command.ExecuteScalar())
                //{

                //}
            }
            return retulst;
        }
        public List<U> ExecuteReader<U>(string query)
        {
            List<U> retulst = new List<U>();
            using (var command = this._dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = System.Data.CommandType.Text;
                //var parameter = new SqlParameter("@p1", ...);
                //command.Parameters.Add(parameter);

                this._dbContext.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        retulst.Add(reader.GetFieldValue<U>(0));
                    }
                }
                //using (var result =<T> command.ExecuteScalar())
                //{

                //}
            }
            return retulst;
        }


        //public T Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    return query.Where(predicate).FirstOrDefault();
        //}

        //public T GetSingle(Expression<Func<T, bool>> predicate)
        //{
        //    return _dbContext.Set<T>().FirstOrDefault(predicate);
        //}

        //public IQueryable<T> GetAll(bool isAsNoTracking = false)
        //{
        //    if (isAsNoTracking)
        //    {
        //        return _dbContext.Set<T>().AsNoTracking();
        //    }
        //    return _dbContext.Set<T>();
        //}

        //public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    IQueryable<T> query = _dbContext.Set<T>();
        //    return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        //}

        //public IQueryable<T> SqlQuery(string query)
        //{
        //    return _dbContext.Set<T>().FromSqlRaw(query);
        //}





        ////public async Task<T> AddAsync(T entity)
        ////{
        ////    _dbContext.Set<T>().Add(entity);
        ////    await _dbContext.SaveChangesAsync();
        ////    return entity;
        ////}

        ////public async Task<T> AddAndReturnAsync(T entity)
        ////{
        ////    _dbContext.Set<T>().Add(entity);
        ////    await _dbContext.SaveChangesAsync();
        ////    return entity;
        ////}

        ////public async Task InsertIfNotExistAsync(Expression<Func<T, Guid>> identifierExpression, List<T> entities)
        ////{
        ////    foreach (var entity in entities)
        ////    {
        ////        var v = identifierExpression.Compile()(entity);
        ////        var predicate = Expression.Lambda<Func<T, bool>>(Expression.Equal(identifierExpression.Body, Expression.Constant(v)), identifierExpression.Parameters);

        ////        var entry = Get(predicate);
        ////        if (entry == null)
        ////        {
        ////            await AddAsync(entity);
        ////        }
        ////    }
        ////}

        ////public async Task<T> UpdateAsync(T entity)
        ////{
        ////    _dbContext.Entry<T>(entity).State = EntityState.Modified;
        ////    await _dbContext.SaveChangesAsync();
        ////    return entity;
        ////}
        //public void DetachAllFromDbContext()
        //{
        //    foreach (var entityEntry in this._dbContext.ChangeTracker.Entries().ToArray())
        //    {
        //        if (entityEntry.Entity != null)
        //        {
        //            entityEntry.State = EntityState.Detached;
        //        }
        //    }
        //}

    }
}