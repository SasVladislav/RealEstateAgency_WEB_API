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
    public interface IRealEstateStatusService : IDisposable
    {
        Task<List<RealEstateStatusDTO>> GetAllRealEstateStatusesAsync(Expression<Func<RealEstateStatusDTO, bool>> where = null);
        Task<RealEstateStatusDTO> GetRealEstateStatusByParamsAsync(Expression<Func<RealEstateStatusDTO, bool>> where);
        Task<RealEstateStatusDTO> GetRealEstateStatusByIdAsync(int id);
        Task<OperationDetails> CreateRealEstateStatusAsync(RealEstateStatusDTO realEstateStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteRealEstateStatusAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateRealEstateStatusAsync(RealEstateStatusDTO realEstateStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<RealEstateStatusDTO>> FilterRealEstateStatusAsync(RealEstateStatusFilterModel realEstateStatusFilter);
    }
}
