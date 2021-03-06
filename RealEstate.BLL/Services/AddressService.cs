﻿using System;
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
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Services
{
    public class AddressService : IAddressService
    {
        IRepository<Address, int> repository;
        IServiceT<Address, AddressDTO, int> service;
        IAddressCityService CityService;
        IAddressRegionService RegionService;
        IAddressStreetService StreetSetvice;
        public AddressService(IRepository<Address, int> repository,
                              IServiceT<Address, AddressDTO, int> service,
                              IAddressCityService cityService,
                              IAddressRegionService regionService,
                              IAddressStreetService streetSetvice)
        {
            this.repository = repository;
            this.service = service;
            this.CityService = cityService;
            this.RegionService = regionService;
            this.StreetSetvice = streetSetvice;
        }
        public async Task<List<AddressViewDTO>> GetAllAddressesViewAsync()
        {
            List<AddressViewDTO> listAddressView = new List<AddressViewDTO>();

            List<AddressDTO> listAddresses = await service.GetAllItemsAsync();
            List<AddressCityDTO> listCities = await CityService.GetAllAddressCitiesAsync();
            List<AddressRegionDTO> listRegions = await RegionService.GetAllAddressRegionsAsync();
            List<AddressStreetDTO> listStreets = await StreetSetvice.GetAllAddressStreetsAsync();            

            List<AddressViewDTO> AllList = listAddresses
                .Join(
                    listCities,
                    a => a.AddressCityID,
                    c => c.AddressCityID,
                    (a, c) => new AddressViewDTO
                    {
                        Address = a,
                        AddressCity=c,
                        AddressRegion=listRegions.Find(x=>x.AddressRegionID==a.AddressRegionID),
                        AddressStreet=listStreets.Find(x=>x.AddressStreetID==a.AddressStreetID)                       
                    }).ToList();

            return AllList;
        }
        public async Task<List<AddressDTO>> GetAllAddressesAsync(Expression<Func<AddressDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }


        public async Task<AddressDTO> GetAddressByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        
        }

        public async Task<AddressDTO> GetAddressByParamsAsync(Expression<Func<AddressDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }
        public async Task<OperationDetails> CreateAddressAsync(AddressDTO addressDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            var resultAddressCreate = await service.CreateItemAsync(addressDto,
                new AddressEquelSpecification(addressDto).ToExpression(),                
                MessageSuccess,
                MessageFail);
            return new OperationDetails(
                                       resultAddressCreate.Item1.Succedeed,
                                       resultAddressCreate.Item1.Message,
                                       resultAddressCreate.Item1.Property,
                                       resultAddressCreate.Item2.AddressID.ToString());            
        }

        public async Task<OperationDetails> DeleteAddressAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id, 
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateAddressAsync(AddressDTO addressDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idAddressDto = addressDto.AddressID;
            return await service.UpdateItemAsync(addressDto,
                    idAddressDto,
                    MessageSuccess,
                    MessageFail);
        }

        public async Task<List<AddressDTO>> FilterAddressAsync(AddressFilterModel addressFilter)
        {
            List<AddressDTO> list = await this.GetAllAddressesAsync();
            if (addressFilter.AddressID != null) list = list.Where(emp => emp.AddressID == addressFilter.AddressID).ToList();
            if (addressFilter.AddressCityID != null) list = list.Where(emp => emp.AddressCityID == addressFilter.AddressCityID).ToList();
            if (addressFilter.AddressRegionID != null) list = list.Where(emp => emp.AddressRegionID == addressFilter.AddressRegionID).ToList();
            if (addressFilter.AddressStreetID != null) list = list.Where(emp => emp.AddressStreetID == addressFilter.AddressStreetID).ToList();
            if (addressFilter.ApartmentNumber != null) list = list.Where(emp => emp.ApartmentNumber == addressFilter.ApartmentNumber).ToList();
            if (addressFilter.HomeNumber != null) list = list.Where(emp => emp.HomeNumber == addressFilter.HomeNumber).ToList();
            return list;
        }

        public void Dispose()
        {
            repository.Dispose();
        }

    }
}
