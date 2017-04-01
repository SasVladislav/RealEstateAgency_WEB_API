using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IAddressStreetService : IDisposable
    {
        Task<List<AddressStreetDTO>> GetAllAddressStreetsAsync(Expression<Func<AddressStreetDTO, bool>> where = null);
        Task<AddressStreetDTO> GetAddressStreetByIdAsync(int id);
        Task<AddressStreetDTO> GetAddressStreetByParamsAsync(Expression<Func<AddressStreetDTO, bool>> where);
        Task<OperationDetails> CreateAddressStreetAsync(AddressStreetDTO addressStreetDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteAddressStreetAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateAddressStreetAsync(AddressStreetDTO addressStreetDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<AddressStreetDTO>> FilterAddressStreetAsync(AddressStreetFilterModel addressStreetFilter);
    }
}
