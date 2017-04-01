using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RealEstateAgency.BLL.Interfaces.GenericInterfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Services.GenericServices
{
    public class GenericServices<T> : IGenericServices<T> where T : class
    {        
        public T NextItem(List<T> GenericList, T CurrentItem)
        {
            int nextIndex= (GenericList.IndexOf(CurrentItem) == -1) ? 1 : GenericList.IndexOf(CurrentItem) + 1;

            if (nextIndex == GenericList.Count)
            {
                return GenericList[0];
            }

            return GenericList[nextIndex];
        }
        public T BackItem(List<T> GenericList, T CurrentItem)
        {
            int nextIndex = (GenericList.IndexOf(CurrentItem) == -1) ? 0 : GenericList.IndexOf(CurrentItem) - 1;

            if (nextIndex == 0)
            {
                return GenericList[0];
            }

            return GenericList[nextIndex];
        }

        public T FirstItem(List<T> GenericList)
        {
            return GenericList.First();
        }

        public T LastItem(List<T> GenericList)
        {
            return GenericList.Last();
        }

        public List<T> FilterForAsync(Expression<Func<T, bool>> where, List<T> GenericList)
        {
            return GenericList.AsQueryable().Where(where).ToList(); // : 
        }
        
    }
}
