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
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using RealEstateAgency.BLL.Service;
using AutoMapper;
using System.Linq.Expressions;
using Ninject;
using RealEstateAgency.BLL.Specifications;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Services
{
    public partial class UserService : IUserService
    {
        IRepository<User, string> repository;
        IUnitOfWorkIdentity identity;
        IServiceT<User, UserDTO, string> service;
        IKernel kernel;
        public UserService(IRepository<User, string> repository,
                                         IUnitOfWorkIdentity identity,
                                         IServiceT<User, UserDTO, string> service,
                                         IKernel kernel)
        {
            this.repository = repository;
            this.identity = identity;
            this.service = service;
            this.kernel = kernel;
        }        
       
        public async Task<List<UserDTO>> GetAllUsersAsync(Expression<Func<UserDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }
        public List<UserViewDTO> GetUsersViewList(
            List<UserDTO> usersList, List<AddressDTO> addressesList)
        {
            List<UserViewDTO> listUsersView = new List<UserViewDTO>();
            Parallel.ForEach(usersList, item =>
             {
                 listUsersView.Add(
                                  new UserViewDTO
                                  {
                                      Person = item,
                                      Address = addressesList
                                          .Where(a => a.AddressID == item.AddressID)
                                          .AsParallel()
                                          .FirstOrDefault()
                                  }
                                 );
             });
            return listUsersView;
        }
        public async Task<List<UserViewDTO>> GetAllUsersViewAsync(Expression<Func<UserDTO, bool>> where = null)
        {        
            List<UserDTO> listUsers = new List<UserDTO>();
            List<AddressDTO> listAddresses = new List<AddressDTO>();

            listUsers = await this.GetAllUsersAsync();
            listAddresses = await kernel.Get<IAddressService>().GetAllAddressesAsync();
            return GetUsersViewList(listUsers, listAddresses);

        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<UserDTO> GetUserByParamsAsync(Expression<Func<UserDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        //---------------------------------------------
        public async Task<OperationDetails> CreateUserAsync(UserDTO userDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.CreateAccountUserAsync(userDto,
                MessageSuccess,
                MessageFail,
                new UserEquelSpecification(userDto).ToExpression());
        }
        public async Task<OperationDetails> CreateUserViewAsync(UserViewDTO userViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail)

        {            
            var resultAddressCreate=await kernel.Get<IAddressService>().CreateAddressAsync
                         (
                            userViewDto.Address,
                            new AddressMessageSpecification().ToSuccessCreateMessage(),
                            new AddressMessageSpecification().ToFailCreateMessage()
                         );
            string addressId = resultAddressCreate.Id;
            userViewDto.Person.AddressID = Convert.ToInt32(addressId);

            OperationDetails UserOperationDetails = await service.CreateAccountUserAsync
                        (
                           userViewDto.Person,                           
                           MessageSuccess,
                           MessageFail,
                           new UserEquelSpecification(userViewDto.Person).ToExpression()
                        );
            return UserOperationDetails;
        }
        public async Task<List<UserViewDTO>> FilterUsersFullNameAsync(UserFilterModel userFilterModel)
        {
            List<UserViewDTO> list = await this.GetAllUsersViewAsync();

            if (userFilterModel.Name != "" && userFilterModel.Surname == "" && userFilterModel.Patronumic == "")
                list = list.Where(x => x.Person.Name == userFilterModel.Name
                                  || x.Person.Surname == userFilterModel.Name
                                  || x.Person.Patronumic == userFilterModel.Name).ToList();

            if (userFilterModel.Name != "" && userFilterModel.Surname != "" && userFilterModel.Patronumic == "")
                list = list.Where(x => x.Person.Name == userFilterModel.Name && x.Person.Surname == userFilterModel.Surname
                                    || x.Person.Surname == userFilterModel.Name && x.Person.Patronumic == userFilterModel.Surname
                                    || x.Person.Name == userFilterModel.Name && x.Person.Patronumic == userFilterModel.Surname).ToList();

            if (userFilterModel.Name != "" && userFilterModel.Surname != "" && userFilterModel.Patronumic != "")
                list = list.Where(x => x.Person.Name == userFilterModel.Name
                                    && x.Person.Surname == userFilterModel.Surname
                                    && x.Person.Name == userFilterModel.Patronumic).ToList();

            return list;
        }
        public async Task<OperationDetails> DeleteUserAsync(string id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            UserDTO user = await service.GetItemByIdAsync(id);
            //AddressDTO address = await this.kernel.Get<IAddressService>().GetAddressByIdAsync(user.AddressID);
            //OperationDetails result1 = await this.kernel.Get<IAddressCityService>().DeleteAddressCityAsync(address.AddressCityID);
            //OperationDetails result2 = await this.kernel.Get<IAddressRegionService>().DeleteAddressRegionAsync(address.AddressRegionID);
            //OperationDetails result3 = await this.kernel.Get<IAddressStreetService>().DeleteAddressStreetAsync(address.AddressStreetID);
            //OperationDetails result4 = await this.kernel.Get<IAddressService>().DeleteAddressAsync(user.AddressID);
            //if (result4.Succedeed==true)
            //{

            //    await service.DeleteItemAsync(id,
            //    new OperationDetails(true, $"Пользователь успешно удален", ""),
            //    new OperationDetails(false, "Такого пользователя нет в базе данных", "User"));
            //    //identity.AppUserManager.DeleteAsync
            //}


            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateUserAsync(UserDTO userDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            string idUserDto = userDto.PersonId;
            return await service.UpdateItemAsync(userDto,
                idUserDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<UserDTO>> FilterUserAsync(UserFilterModel userFilter)
        {
            List<UserDTO> list = await this.GetAllUsersAsync();
            if (userFilter.PersonId != null) list = list.Where(emp => emp.PersonId == userFilter.PersonId).ToList();
            if (userFilter.Name != null) list = list.Where(emp => emp.Name == userFilter.Name).ToList();
            if (userFilter.Surname != null) list = list.Where(emp => emp.Surname == userFilter.Surname).ToList();
            if (userFilter.Patronumic != null) list = list.Where(emp => emp.Patronumic == userFilter.Patronumic).ToList();
            if (userFilter.AddressID != null) list = list.Where(emp => emp.AddressID == userFilter.AddressID).ToList();
            if (userFilter.PhoneNumber != null) list = list.Where(emp => emp.PhoneNumber == userFilter.PhoneNumber).ToList();
            return list;
        }
    }
}
