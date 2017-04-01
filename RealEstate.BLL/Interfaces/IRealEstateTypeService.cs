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
    public interface IRealEstateTypeService : IDisposable
    {
        Task<List<RealEstateTypeDTO>> GetAllRealEstateTypesAsync(Expression<Func<RealEstateTypeDTO, bool>> where = null);
        Task<RealEstateTypeDTO> GetRealEstateTypeByParamsAsync(Expression<Func<RealEstateTypeDTO, bool>> where);
        Task<RealEstateTypeDTO> GetRealEstateTypeByIdAsync(int id);
        Task<OperationDetails> CreateRealEstateTypeAsync(RealEstateTypeDTO realEstateTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteRealEstateTypeAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateRealEstateTypeAsync(RealEstateTypeDTO realEstateTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<RealEstateTypeDTO>> FilterRealEstateTypeAsync(RealEstateTypeFilterModel realEstateTypeFilter);
    }
}
