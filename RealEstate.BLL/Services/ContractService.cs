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
    public class ContractService : IContractService
    {
        IRepository<Contract, int> repository;
        IServiceT<Contract, ContractDTO, int> service;
        public ContractService(IRepository<Contract, int> repository,
                                         IServiceT<Contract, ContractDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }
        
        public async Task<List<ContractDTO>> GetAllContractsAsync(Expression<Func<ContractDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<ContractDTO> GetContractByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<ContractDTO> GetContractByParamsAsync(Expression<Func<ContractDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }
        public async Task<OperationDetails> CreateContractAsync(ContractDTO contractDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(contractDto,
               new ContractEquelSpecification(contractDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteContractAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateContractAsync(ContractDTO contractDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idContractDto = contractDto.ContractID;
            return await service.UpdateItemAsync(contractDto,
                idContractDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<ContractDTO>> FilterContractAsync(ContractFilterModel contractFilter)
        {
            List<ContractDTO> list = await this.GetAllContractsAsync();
            if (contractFilter.BuyerID != null) list = list.Where(emp => emp.BuyerID == contractFilter.BuyerID).ToList();
            if (contractFilter.ContractID != null) list = list.Where(emp => emp.ContractID == contractFilter.ContractID).ToList();
            if (contractFilter.ContractTypeID != null) list = list.Where(emp => emp.ContractTypeID == contractFilter.ContractTypeID).ToList();
            if (contractFilter.EmployeeID != null) list = list.Where(emp => emp.EmployeeID == contractFilter.EmployeeID).ToList();
            if (contractFilter.RealEstateID != null) list = list.Where(emp => emp.RealEstateID == contractFilter.RealEstateID).ToList();
            if (contractFilter.SellerID != null) list = list.Where(emp => emp.SellerID == contractFilter.SellerID).ToList();
            if (contractFilter.RecordDate != null) list = list.Where(emp => emp.RecordDate == contractFilter.RecordDate).ToList();
            //if (contractFilter.BeginRecordDate != null) list = list.Where(emp => emp.BeginRecordDate == contractFilter.BeginRecordDate).ToList();
            //if (contractFilter.EndRecordDate != null) list = list.Where(emp => emp.EndRecordDate == contractFilter.EndRecordDate).ToList();
            return list;
        }
    }
}
