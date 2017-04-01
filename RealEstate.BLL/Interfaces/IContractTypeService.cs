using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.DAL.Entities;
using System.Linq.Expressions;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IContractTypeService : IDisposable
    {
        Task<List<ContractTypeDTO>> GetAllContractTypesAsync(Expression<Func<ContractTypeDTO, bool>> where = null);
        Task<ContractTypeDTO> GetContractTypeByIdAsync(int id);
        Task<ContractTypeDTO> GetContractTypeByParamsAsync(Expression<Func<ContractTypeDTO, bool>> where);
        Task<OperationDetails> CreateContractTypeAsync(ContractTypeDTO contractTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteContractTypeAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateContractTypeAsync(ContractTypeDTO contractTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<ContractTypeDTO>> FilterContactTypeAsync(ContractTypeFilterModel contractTypeFilter);
    }
}
