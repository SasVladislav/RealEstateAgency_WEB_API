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
    public class AddressStreetService : IAddressStreetService
    {
        IRepository<AddressStreet, int> repository;
        IServiceT<AddressStreet, AddressStreetDTO, int> service;
        public AddressStreetService(IRepository<AddressStreet, int> repository,
                                         IServiceT<AddressStreet, AddressStreetDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<AddressStreetDTO>> GetAllAddressStreetsAsync(Expression<Func<AddressStreetDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<AddressStreetDTO> GetAddressStreetByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<AddressStreetDTO> GetAddressStreetByParamsAsync(Expression<Func<AddressStreetDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateAddressStreetAsync(AddressStreetDTO addressStreetDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(addressStreetDto,
                new AddressStreetEquelSpecification(addressStreetDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteAddressStreetAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateAddressStreetAsync(AddressStreetDTO addressStreetDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idStreetDto = addressStreetDto.AddressStreetID;
            return await service.UpdateItemAsync(addressStreetDto,
                idStreetDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<AddressStreetDTO>> FilterAddressStreetAsync(AddressStreetFilterModel addressStreetFilter)
        {
            List<AddressStreetDTO> list = await this.GetAllAddressStreetsAsync();
            if (addressStreetFilter.AddressStreetID != null) list = list.Where(emp => emp.AddressStreetID == addressStreetFilter.AddressStreetID).ToList();
            if (addressStreetFilter.AddressStreetName != null) list = list.Where(emp => emp.AddressStreetName == addressStreetFilter.AddressStreetName).ToList();
            return list;
        }
    }
}
