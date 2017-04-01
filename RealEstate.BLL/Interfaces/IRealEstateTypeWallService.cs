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
    public interface IRealEstateTypeWallService : IDisposable
    {
        Task<List<RealEstateTypeWallDTO>> GetAllRealEstateTypeWallsAsync(Expression<Func<RealEstateTypeWallDTO, bool>> where = null);
        Task<RealEstateTypeWallDTO> GetRealEstateTypeWallByParamsAsync(Expression<Func<RealEstateTypeWallDTO, bool>> where);
        Task<RealEstateTypeWallDTO> GetRealEstateTypeWallByIdAsync(int id);
        Task<OperationDetails> CreateRealEstateTypeWallAsync(RealEstateTypeWallDTO realEstateTypeWallDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteRealEstateTypeWallAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateRealEstateTypeWallAsync(RealEstateTypeWallDTO realEstateTypeWallDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<RealEstateTypeWallDTO>> FilterRealEstateTypeWallAsync(RealEstateTypeWallFilterModel realEstateTypeWallFilter);
    }
}
