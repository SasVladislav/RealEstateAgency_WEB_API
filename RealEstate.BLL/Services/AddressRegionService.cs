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
    public class AddressRegionService : IAddressRegionService
    {
        IRepository<AddressRegion, int> repository;
        IServiceT<AddressRegion, AddressRegionDTO, int> service;
        public AddressRegionService(IRepository<AddressRegion, int> repository,
                                         IServiceT<AddressRegion, AddressRegionDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }
        public async Task<List<AddressRegionDTO>> GetAllAddressRegionsAsync(Expression<Func<AddressRegionDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<AddressRegionDTO> GetAddressRegionByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }
        public async Task<AddressRegionDTO> GetAddressRegionByParamsAsync(Expression<Func<AddressRegionDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateAddressRegionAsync(AddressRegionDTO addressRegionDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(addressRegionDto,
                new AddressRegionEquelSpecification(addressRegionDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteAddressRegionAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateAddressRegionAsync(AddressRegionDTO addressRegionDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idRegionDto = addressRegionDto.AddressRegionID;
            return await service.UpdateItemAsync(addressRegionDto,
                idRegionDto,
                MessageSuccess,
                MessageFail);           
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<AddressRegionDTO>> FilterAddressRegionAsync(AddressRegionFilterModel addressRegionFilter)
        {
            List<AddressRegionDTO> list = await this.GetAllAddressRegionsAsync();
            if (addressRegionFilter.AddressRegionID != null) list = list.Where(emp => emp.AddressRegionID == addressRegionFilter.AddressRegionID).ToList();
            if (addressRegionFilter.AddressRegionName != null) list = list.Where(emp => emp.AddressRegionID == addressRegionFilter.AddressRegionID).ToList();
            return list;
        }
    }
}
