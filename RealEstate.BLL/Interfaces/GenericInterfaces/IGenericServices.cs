using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Interfaces.GenericInterfaces
{
    public interface IGenericServices<TEntity>where TEntity:class
    {
        TEntity NextItem(List<TEntity> GenericList, TEntity CurrentItem);
        TEntity BackItem(List<TEntity> GenericList, TEntity CurrentItem);
        TEntity FirstItem(List<TEntity> GenericList);
        TEntity LastItem(List<TEntity> GenericList);
        List<TEntity> FilterForAsync(Expression<Func<TEntity, bool>> where, List<TEntity> GenericList);
    }
}
