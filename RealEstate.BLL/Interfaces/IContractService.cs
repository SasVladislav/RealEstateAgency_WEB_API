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
    public interface IContractService : IDisposable
    {
        Task<List<ContractViewDTO>> GetAllContractsViewAsync();
        Task<List<ContractDTO>> GetAllContractsAsync(Expression<Func<ContractDTO, bool>> where = null);
        Task<ContractDTO> GetContractByIdAsync(int id);
        Task<ContractDTO> GetContractByParamsAsync(Expression<Func<ContractDTO, bool>> where);
        Task<OperationDetails> CreateContractAsync(ContractDTO contractDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteContractAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateContractAsync(ContractDTO contractDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<ContractDTO>> FilterContractAsync(ContractFilterModel contractFilter);
    }
}
