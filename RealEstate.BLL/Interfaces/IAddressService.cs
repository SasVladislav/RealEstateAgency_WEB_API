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
    public interface IAddressService : IDisposable
    {
        Task<List<AddressDTO>> GetAllAddressesAsync(Expression<Func<AddressDTO, bool>> where = null);
        Task<AddressDTO> GetAddressByIdAsync(int id);
        Task<AddressDTO> GetAddressByParamsAsync(Expression<Func<AddressDTO, bool>> where);
        Task<OperationDetails> CreateAddressAsync(AddressDTO addressDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteAddressAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateAddressAsync(AddressDTO addressDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<AddressDTO>> FilterAddressAsync(AddressFilterModel addressFilter);
    }
}
