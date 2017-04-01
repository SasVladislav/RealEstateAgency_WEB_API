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
    public interface IAddressRegionService : IDisposable
    {
        Task<List<AddressRegionDTO>> GetAllAddressRegionsAsync(Expression<Func<AddressRegionDTO, bool>> where = null);
        Task<AddressRegionDTO> GetAddressRegionByIdAsync(int id);
        Task<AddressRegionDTO> GetAddressRegionByParamsAsync(Expression<Func<AddressRegionDTO, bool>> where);
        Task<OperationDetails> CreateAddressRegionAsync(AddressRegionDTO addressRegionDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteAddressRegionAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateAddressRegionAsync(AddressRegionDTO addressRegionDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<AddressRegionDTO>> FilterAddressRegionAsync(AddressRegionFilterModel addressRegionFilter);
    }
}
