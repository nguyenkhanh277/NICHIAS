using NICHIAS.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NICHIAS.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public bool error = false;
        public string errorMessage = "";
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(string id)
        {
            // Here we are working with a DbContext, not PlutoContext. So we don't have DbSets 
            // such as Courses or Authors, and we need to use the generic Set() method to access them.
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            // Note that here I've repeated Context.Set<TEntity>() in every method and this is causing
            // too much noise. I could get a reference to the DbSet returned from this method in the 
            // constructor and store it in a private field like _entities. This way, the implementation
            // of our methods would be cleaner:
            // 
            // _entities.ToList();
            // _entities.Where();
            // _entities.FirstOrDefault();
            // 
            // I didn't change it because I wanted the code to look like the videos. But feel free to change
            // this on your own.
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Where(expression);
        }

        public IEnumerable<TEntity> Find(IEnumerable<Expression<Func<TEntity, bool>>> expressions)
        {
            var queryable = Context.Set<TEntity>().AsQueryable();
            foreach (Expression<Func<TEntity, bool>> expression in expressions)
            {
                queryable = queryable.Where(expression);
            }
            return queryable.ToList();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().FirstOrDefault(expression);
        }

        public void Add(TEntity entity)
        {
            error = false;
            errorMessage = "";
            try
            {
                Context.Set<TEntity>().Add(entity);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            error = false;
            errorMessage = "";
            try
            {
                Context.Set<TEntity>().AddRange(entities);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }

        public void Remove(string id)
        {
            Remove(Get(id));
        }

        public void Remove(TEntity entity)
        {
            error = false;
            errorMessage = "";
            try
            {
                Context.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            error = false;
            errorMessage = "";
            try
            {
                Context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                error = true;
                errorMessage = ex.ToString();
            }
        }
    }
}