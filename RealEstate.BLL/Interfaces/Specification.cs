using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Interfaces
{
    public abstract class Specification<TEntity,TEntityDto>
    {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

    }
}
