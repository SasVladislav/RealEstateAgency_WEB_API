using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Identity;

namespace RealEstateAgency.DAL.Interfaces
{
   public interface IRepository<TEntity,in Tkey> : IDisposable where TEntity : class 
    {
        
        /// Creates a new empty entity.
        TEntity Create();

        /// Creates the existing entity.
        TEntity Create(TEntity entity);
       
        /// Updates the existing entity.
        TEntity Update(TEntity entity);

        /// Delete an entity using its primary key.
        Task DeleteAsync(Tkey id);

        /// Delete the given entity.
        void Delete(TEntity entity);

        /// Deletes the existing entity.
        void Delete(Expression<Func<TEntity, bool>> where);

        /// Finds one entity based on provided criteria.
        Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> where = null);

        /// Finds one entity based on its Identifier.
        Task<TEntity> FindByIdAsync(Tkey id);

        /// Finds entities based on provided criteria.
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> where = null);

        /// Finds other related entities based of type T for queries.
        IQueryable<T> Set<T>() where T : class;

        /// Save any changes to the TContext
        bool SaveChanges();
        Task<bool> SaveChangesAsync();

    }
    ///*Task<TKey>*/
    //void SaveAsync(TEntity item);
    //Task<TEntity> DeleteAsync(TEntity itemId);
}
