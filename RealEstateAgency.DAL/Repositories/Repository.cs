using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;

namespace RealEstateAgency.DAL.Repositories
{
    public class Repository<TEntity,Tkey> : IRepository<TEntity,Tkey>, IDisposable
        where TEntity : class
    {
        protected IdentityDbContext Context;
        

        public Repository(IdentityDbContext dbContext)
        {
            Context = dbContext;            
        }

        public virtual TEntity Create()
        {
            return Context.Set<TEntity>().Create();
        }

        public virtual TEntity Create(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Set<TEntity>().AddOrUpdate(entity);
            return entity;
        }

        public virtual async Task DeleteAsync(Tkey id)
        {
            var item = await Context.Set<TEntity>().FindAsync(id);
            Context.Set<TEntity>().Remove(item);
        }

        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            var objects = Context.Set<TEntity>().Where(where).AsEnumerable();
            foreach (var item in objects)
            {
                Context.Set<TEntity>().Remove(item);
            }
        }

        public virtual async Task<TEntity> FindByIdAsync(Tkey id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(where);
        }

        public IQueryable<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        public virtual async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null)
        {
            return  null != where ? await Context.Set<TEntity>().Where(where).ToListAsync() : await Context.Set<TEntity>().ToListAsync();//predicate
        }

        public virtual bool SaveChanges()
        {
            return 0 < Context.SaveChanges();
        }
        /// <summary>
        /// Releases all resources used by the Entities
        /// </summary>
        public void Dispose()
        {
            if (null != Context)
            {
                Context.Dispose();
            }
        }

        public virtual async Task<bool> SaveChangesAsync()
        {
            return  0 < await Context.SaveChangesAsync();
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        //private bool disposed = false;
        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            userManager.Dispose();
        //            roleManager.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}


    }
}

