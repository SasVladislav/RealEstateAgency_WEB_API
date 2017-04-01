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
    public class AddressCityService:IAddressCityService
    {
        IRepository<AddressCity, int> repository;
        IServiceT<AddressCity, AddressCityDTO, int> service;
        public AddressCityService(IRepository<AddressCity,int> repository,
                                         IServiceT<AddressCity, AddressCityDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }
        public async Task<List<AddressCityDTO>> GetAllAddressCitiesAsync(Expression<Func<AddressCityDTO, bool>> where=null)
        {
            return await service.GetAllItemsAsync(where);

        }

        public async Task<AddressCityDTO> GetAddressCityByParamsAsync(Expression<Func<AddressCityDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<AddressCityDTO> GetAddressCityByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }
        public async Task<OperationDetails> CreateAddressCityAsync(AddressCityDTO addressCityDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(addressCityDto,
                new AddressCityEquelSpecification(addressCityDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteAddressCityAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);           
        }

        public async Task<OperationDetails> UpdateAddressCityAsync(AddressCityDTO addressCityDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idCityDto = addressCityDto.AddressCityID;
            return await service.UpdateItemAsync(addressCityDto,
                idCityDto,
                MessageSuccess,
                MessageFail);
        }

        

        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<AddressCityDTO>> FilterAddressCityAsync(AddressCityFilterModel addressCityFilter)
        {
            List<AddressCityDTO> list = await this.GetAllAddressCitiesAsync();
            if (addressCityFilter.AddressCityID != null) list = list.Where(emp => emp.AddressCityID == addressCityFilter.AddressCityID).ToList();
            if (addressCityFilter.AddressCityName != null) list = list.Where(emp => emp.AddressCityName == addressCityFilter.AddressCityName).ToList();
            return list;
        }
    }
}
