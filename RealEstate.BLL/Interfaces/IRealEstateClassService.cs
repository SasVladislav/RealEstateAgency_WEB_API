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
    public interface IRealEstateClassService : IDisposable
    {
        Task<List<RealEstateClassDTO>> GetAllRealEstateClassesAsync(Expression<Func<RealEstateClassDTO, bool>> where = null);
        Task<RealEstateClassDTO> GetRealEstateClassByParamsAsync(Expression<Func<RealEstateClassDTO, bool>> where);
        Task<RealEstateClassDTO> GetRealEstateClassByIdAsync(int id);
        Task<OperationDetails> CreateRealEstateClassAsync(RealEstateClassDTO realEstateClassDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteRealEstateClassAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateRealEstateClassAsync(RealEstateClassDTO realEstateClassDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<RealEstateClassDTO>> FilterRealEstateClassAsync(RealEstateClassFilterModel realEstateClassFilter);
    }
}
