using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Service
{
    public interface IServiceT<TEntity,TEntityDto,TType>:IDisposable
        where TEntity:class
        where TEntityDto:class
    {
        Task<List<TEntityDto>> GetAllItemsAsync(Expression<Func<TEntityDto, bool>> where = null);
        Task<TEntityDto> GetItemByIdAsync(TType idDb);
        Task<TEntityDto> GetItemByParamsAsync(Expression<Func<TEntityDto, bool>> where);
        Task<Tuple<OperationDetails, TEntityDto>> CreateItemAsync(TEntityDto ItemDto, Expression<Func<TEntity, bool>> where,
                                               OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> CreateAccountUserAsync(TEntityDto PersonDto, OperationDetails MessageSuccess,
                                                     OperationDetails MessageFail, Expression<Func<TEntity, bool>> where = null);
        Task<OperationDetails> DeleteItemAsync(TType id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateItemAsync(TEntityDto ItemDto, TType idDto,
                                               OperationDetails MessageSuccess, OperationDetails MessageFail);
    }
}
