using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IRealEstateService : IDisposable
    {
        Task<List<RealEstateDTO>> GetAllRealEstatesAsync(Expression<Func<RealEstateDTO, bool>> where = null);
        Task<List<RealEstateViewDTO>> GetAllRealEstatesViewAsync(Expression<Func<RealEstateDTO, bool>> where = null);
        Task<RealEstateDTO> GetRealEstateByParamsAsync(Expression<Func<RealEstateDTO, bool>> where);
        Task<RealEstateDTO> GetRealEstateByIdAsync(int id);
        Task<OperationDetails> CreateRealEstateAsync(RealEstateViewDTO realEstateViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteRealEstateAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateRealEstateAsync(RealEstateDTO realEstateDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<RealEstateDTO>> FilterRealEstateAsync(RealEstateFilterModel realEstateFilter);
        Task<List<RealEstateViewDTO>> GetAllFilterRealEstatesViewAsync(RealEstateFilterViewDTO realEstateFilterView);
    }
}
