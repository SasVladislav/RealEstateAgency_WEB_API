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
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;
using Ninject;
using System.Diagnostics;

namespace RealEstateAgency.BLL.Services
{
    public class RealEstateService : IRealEstateService
    {
        IRepository<RealEstate, int> repository;
        IServiceT<RealEstate, RealEstateDTO, int> service;
        IKernel kernel;
        public RealEstateService(IRepository<RealEstate, int> repository,
                                 IServiceT<RealEstate, RealEstateDTO, int> service,
                                 IKernel kernel)
        {
            this.repository = repository;
            this.service = service;
            this.kernel = kernel;
        }
        public List<RealEstateViewDTO> GetRealEstateViewList(
            List<RealEstateDTO> realestateList,List<AddressDTO> addressList)
        {
            List<RealEstateViewDTO> listRealEstateView = new List<RealEstateViewDTO>();
            Parallel.ForEach(realestateList,item=>
            {
            if (addressList.Where(a => a.AddressID == item.AddressID).AsParallel().Count() != 0)
            {
                listRealEstateView.Add(
                                 new RealEstateViewDTO
                                 {
                                     RealEstate = item,
                                     Address = addressList.Where(a=>a.AddressID==item.AddressID).AsParallel().FirstOrDefault()
                                 }
                                );
                }
            });
            return listRealEstateView;
        }
        public async Task<List<RealEstateDTO>> GetAllRealEstatesAsync(Expression<Func<RealEstateDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }
        public async Task<List<RealEstateViewDTO>> GetAllRealEstatesViewAsync(Expression<Func<RealEstateDTO, bool>> where = null)
        {        
            List<RealEstateDTO> listRealEstates = new List<RealEstateDTO>();
            List<AddressDTO> listAddresses = new List<AddressDTO>();
            listRealEstates = await service.GetAllItemsAsync(where);
            listAddresses = await kernel.Get<IAddressService>().GetAllAddressesAsync();
            return this.GetRealEstateViewList(listRealEstates, listAddresses);
            
        }

        public async Task<RealEstateDTO> GetRealEstateByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }


        public async Task<RealEstateDTO> GetRealEstateByParamsAsync(Expression<Func<RealEstateDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }


        public async Task<OperationDetails> CreateRealEstateAsync(RealEstateViewDTO realEstateViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            var resultAddress = await kernel.Get<IAddressService>().CreateAddressAsync
                         (
                            realEstateViewDto.Address,
                            new AddressMessageSpecification().ToSuccessCreateMessage(),
                            new AddressMessageSpecification().ToFailCreateMessage()
                         );
            string addressId = resultAddress.Id;

            realEstateViewDto.RealEstate.AddressID = Convert.ToInt32(addressId);
            var resultRealEstate=await service.CreateItemAsync
                        (
                           realEstateViewDto.RealEstate,
                           new RealEstateEquelSpecification(realEstateViewDto.RealEstate).ToExpression(),
                           MessageSuccess,
                           MessageFail
                        );
            return new OperationDetails
                        (
                         resultRealEstate.Item1.Succedeed,
                         resultRealEstate.Item1.Message,
                         resultRealEstate.Item1.Property,
                         resultRealEstate.Item2.RealEstateID.ToString());
        }

        public async Task<OperationDetails> DeleteRealEstateAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateRealEstateAsync(RealEstateDTO realEstateDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idRealEstate = realEstateDto.RealEstateID;
            return await service.UpdateItemAsync(realEstateDto,
                idRealEstate,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<RealEstateDTO>> FilterRealEstateAsync(RealEstateFilterModel realEstateFilter)
        {
            List<RealEstateDTO> list = await this.GetAllRealEstatesAsync();
            if (realEstateFilter.RealEstateID != null) list = list.Where(emp => emp.RealEstateID == realEstateFilter.RealEstateID).ToList();
            if (realEstateFilter.RealEstateClassID != null) list = list.Where(emp => emp.RealEstateClassID == realEstateFilter.RealEstateClassID).ToList();
            if (realEstateFilter.RealEstateStatusID != null) list = list.Where(emp => emp.RealEstateStatusID == realEstateFilter.RealEstateStatusID).ToList();
            if (realEstateFilter.RealEstateTypeID != null) list = list.Where(emp => emp.RealEstateTypeID == realEstateFilter.RealEstateTypeID).ToList();
            if (realEstateFilter.RealEstateTypeWallID != null) list = list.Where(emp => emp.RealEstateTypeWallID == realEstateFilter.RealEstateTypeWallID).ToList();
            if (realEstateFilter.AddressID != null) list = list.Where(emp => emp.AddressID == realEstateFilter.AddressID).ToList();
            if (realEstateFilter.Elevator != null) list = list.Where(emp => emp.Elevator == realEstateFilter.Elevator).ToList();
            if (realEstateFilter.NearSubway != null) list = list.Where(emp => emp.NearSubway == realEstateFilter.NearSubway).ToList();
            if (realEstateFilter.BeginLevel != null) list = list.Where(emp => emp.NumberOfRooms >= realEstateFilter.BeginLevel).ToList();
            if (realEstateFilter.EndLevel != null) list = list.Where(emp => emp.Price <= realEstateFilter.EndLevel).ToList();
            if (realEstateFilter.BeginPrice != null) list = list.Where(emp => emp.Price >= realEstateFilter.BeginPrice).ToList();
            if (realEstateFilter.EndPrice != null) list = list.Where(emp => emp.Price <= realEstateFilter.EndPrice).ToList();
            if (realEstateFilter.BeginGrossArea != null) list = list.Where(emp => emp.GrossArea >= realEstateFilter.BeginGrossArea).ToList();
            if (realEstateFilter.EndGrossArea != null) list = list.Where(emp => emp.GrossArea <= realEstateFilter.EndGrossArea).ToList();
            if (realEstateFilter.BeginNumberOfRooms != null) list = list.Where(emp => emp.NumberOfRooms >= realEstateFilter.BeginNumberOfRooms).ToList();
            if (realEstateFilter.EndNumberOfRooms != null) list = list.Where(emp => emp.NumberOfRooms <= realEstateFilter.EndNumberOfRooms).ToList();
            return list;
        }
        public async Task<List<RealEstateViewDTO>> GetAllFilterRealEstatesViewAsync(RealEstateFilterViewDTO realEstateFilterView)
        {
            List<RealEstateDTO> listRealEstates = new List<RealEstateDTO>();
            List<AddressDTO> listAddresses = new List<AddressDTO>();

            listAddresses = await kernel.Get<IAddressService>().FilterAddressAsync(realEstateFilterView.AddressFilter);
            listRealEstates = await this.FilterRealEstateAsync(realEstateFilterView.RealEstateFilter);

            return listRealEstates.Count != 0?
                this.GetRealEstateViewList(listRealEstates, listAddresses):
                new List<RealEstateViewDTO>();
        }
    }
}
