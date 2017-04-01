using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.DAL.Interfaces;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Repositories;
using RealEstateAgency.DAL.EF;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Service;
using System.Linq.Expressions;
using RealEstateAgency.BLL.Specifications;

namespace RealEstateAgency.BLL.Services
{
    public class ContractTypeService : IContractTypeService
    {
        IRepository<ContractType, int> repository;
        IServiceT<ContractType, ContractTypeDTO, int> service;
        public ContractTypeService(IRepository<ContractType, int> repository,
                                   IServiceT<ContractType, ContractTypeDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<ContractTypeDTO>> GetAllContractTypesAsync(Expression<Func<ContractTypeDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<ContractTypeDTO> GetContractTypeByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<ContractTypeDTO> GetContractTypeByParamsAsync(Expression<Func<ContractTypeDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateContractTypeAsync(ContractTypeDTO contractTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(contractTypeDto,
                new ContractTypeEquelSpecification(contractTypeDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteContractTypeAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateContractTypeAsync(ContractTypeDTO contractTypeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idTypeDto = contractTypeDto.ContractTypeID;
            return await service.UpdateItemAsync(contractTypeDto,
                idTypeDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<ContractTypeDTO>> FilterContactTypeAsync(ContractTypeFilterModel contractTypeFilter)
        {
            List<ContractTypeDTO> list = await this.GetAllContractTypesAsync();
            if (contractTypeFilter.ContractTypeID != null) list = list.Where(emp => emp.ContractTypeID == contractTypeFilter.ContractTypeID).ToList();
            if (contractTypeFilter.ContractTypeName != null) list = list.Where(emp => emp.ContractTypeName == contractTypeFilter.ContractTypeName).ToList();
            return list;
        }
    }
}
