using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RealEstateAgency.API.Controllers
{
    [RoutePrefix("Contract")]
    public class ContractController : ApiController
    {
        IContractService contractService;
        IContractTypeService contractTypeService;
        public ContractController(IContractService contractService,
                                  IContractTypeService contractTypeService)
        {
            this.contractService = contractService;
            this.contractTypeService = contractTypeService;
        }

        #region Contract
        //-----Contract
        [Route("GetAllContracts")]
        [HttpGet]
        public async Task<List<ContractDTO>> GetAllContracts()
        {
            return await contractService.GetAllContractsAsync();
        }
        [Route("GetContract")]
        [HttpPost]
        public async Task<ContractDTO> GetContract(SendIDToWebApiDTO SendID)
        {
            int idContract = SendID.IdInt;
            return await contractService.GetContractByIdAsync(idContract);
        }
        [Route("CreateContract")]
        [HttpPost]
        public async Task<OperationDetails> CreateContract(ContractDTO ContractDto)
        {
            return await contractService.CreateContractAsync(ContractDto,
               new ContractMessageSpecification().ToSuccessCreateMessage(),
               new ContractMessageSpecification().ToFailCreateMessage());
        }
        [Route("DeleteContract")]
        [HttpPost]
        public async Task<OperationDetails> DeleteContract(SendIDToWebApiDTO SendID)
        {
            int idContract = SendID.IdInt;
            return await contractService.DeleteContractAsync(idContract,
                new ContractMessageSpecification().ToSuccessDeleteMessage(),
                new ContractMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateContract")]
        [HttpPost]
        public async Task<OperationDetails> UpdateContract(ContractDTO ContractDto)
        {
            return await contractService.UpdateContractAsync(ContractDto,
                    new ContractMessageSpecification().ToSuccessUpdateMessage(),
                    new ContractMessageSpecification().ToFailUpdateMessage());
        }

        [Route("FilterContract")]
        [HttpPost]
        public async Task<List<ContractDTO>> FilterContract(ContractFilterModel ContractDto)
        {
            return await contractService.FilterContractAsync(ContractDto);           
        }
        #endregion

        #region ContractType
        //-----Address
        [Route("GetAllTypes")]
        [HttpGet]
        public async Task<List<ContractTypeDTO>> GetAllTypes()
        {
            return await contractTypeService.GetAllContractTypesAsync();
        }
        [Route("GetType")]
        [HttpPost]
        public async Task<ContractTypeDTO> GetType(SendIDToWebApiDTO SendID)
        {
            int idType = SendID.IdInt;
            return await contractTypeService.GetContractTypeByIdAsync(idType);
        }
        [Route("CreateType")]
        [HttpPost]
        public async Task<OperationDetails> CreateType(ContractTypeDTO TypeDto)
        {
            return await contractTypeService.CreateContractTypeAsync(TypeDto,
                new ContractTypeMessageSpecification(TypeDto).ToSuccessCreateMessage(),
                new ContractTypeMessageSpecification(TypeDto).ToFailCreateMessage());
        }
        [Route("DeleteType")]
        [HttpPost]
        public async Task<OperationDetails> DeleteType(SendIDToWebApiDTO SendID)
        {
            int idType = SendID.IdInt;
            return await contractTypeService.DeleteContractTypeAsync(idType,
                new ContractTypeMessageSpecification().ToSuccessDeleteMessage(),
                new ContractTypeMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateType")]
        [HttpPost]
        public async Task<OperationDetails> UpdateType(ContractTypeDTO TypeDto)
        {
            return await contractTypeService.UpdateContractTypeAsync(TypeDto,
                    new ContractTypeMessageSpecification(TypeDto).ToSuccessUpdateMessage(),
                    new ContractTypeMessageSpecification(TypeDto).ToFailUpdateMessage());
        }
        [Route("FilterType")]
        [HttpPost]
        public async Task<List<ContractTypeDTO>> FilterType(ContractTypeFilterModel TypeDto)
        {
            return await contractTypeService.FilterContactTypeAsync(TypeDto);
        }
        #endregion
    }
}
