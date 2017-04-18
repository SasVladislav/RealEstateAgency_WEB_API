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
using Ninject;
using AutoMapper;
using System.Linq.Expressions;
using RealEstateAgency.BLL.Specifications;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        IRepository<Employee, string> repository;
        IServiceT<Employee, EmployeeDTO, string> service;
        IAddressService AddressService;
        IEmployeeDismissService DismissService;
        IKernel kernel;
        public EmployeeService(IRepository<Employee, string> repository,
                                         IServiceT<Employee, EmployeeDTO, string> service,
                                         IAddressService addressService,
                                         IEmployeeDismissService dismissService,
                                         IKernel kernel)
        {
            this.repository = repository;
            this.service = service;
            this.kernel = kernel;
            this.AddressService = addressService;
            this.DismissService = dismissService;
        }
        
        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync(Expression<Func<EmployeeDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }
        public async Task<List<EmployeeViewDTO>> GetAllEmployeesViewAsync()
        {
            List<EmployeeViewDTO> listEmployeeView = new List<EmployeeViewDTO>();

            List<EmployeeDTO>  listEmployees = await service.GetAllItemsAsync();
            List<AddressDTO>  listAddresses = await AddressService.GetAllAddressesAsync();
            List<EmployeeDismissDTO>  listDismiss = await DismissService.GetAllEmployeeDismissesAsync();

            List<EmployeeViewDTO> AllList = listEmployees
                .Join(
                    listAddresses,
                    e => e.AddressID,
                    a => a.AddressID,
                    (e, a) => new EmployeeViewDTO
                    {

                        Person = e,
                        Address = a,
                        Dismisses= listDismiss
                                    .Where(d=>d.EmployeeId==e.PersonId)
                                    .ToList()
                    }).ToList();

            return AllList;
        }
        public async Task<EmployeeDTO> GetEmployeeByIdAsync(string id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<EmployeeDTO> GetEmployeeByParamsAsync(Expression<Func<EmployeeDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateEmployeeAsync(EmployeeDTO employeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {

            return await service.CreateAccountUserAsync(employeeDto,
                MessageSuccess,
                MessageFail,
                new EmployeeEquelSpecification(employeeDto).ToExpression()
                );

        }
        public async Task<OperationDetails> CreateEmployeeViewAsync(EmployeeViewDTO employeeViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {

            var resultAddressCreate=await AddressService.CreateAddressAsync
                         (
                            employeeViewDto.Address,
                            new AddressMessageSpecification().ToSuccessCreateMessage(),
                            new AddressMessageSpecification().ToFailCreateMessage()
                         );
            string addressId = resultAddressCreate.Id;
            employeeViewDto.Person.AddressID = Convert.ToInt32(addressId);
            OperationDetails UserOperationDetails = await service.CreateAccountUserAsync(employeeViewDto.Person,
                MessageSuccess,
                MessageFail,
                new EmployeeEquelSpecification(employeeViewDto.Person).ToExpression()
                );

            return UserOperationDetails;

        }
        public async Task<OperationDetails> CreateExistEmployeeAsync(string IdEmployeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            List<EmployeeDismissDTO> listDismEmp =
            await kernel.Get<IEmployeeDismissService>().GetAllEmployeeDismissesByIdEmployeeAsync(IdEmployeeDto);

            EmployeeDismissDTO DismEmp = listDismEmp.Last();
            EmployeeDTO empl = await GetEmployeeByIdAsync(IdEmployeeDto);
            if (DismEmp.DismissDate!=null && empl != null)
            {
                empl.EmployeeStatusID = (await kernel.Get<IEmployeeStatusService>().GetEmployeeStatusByParamsAsync(Status => Status.EmployeeStatusName == "Worker")).EmployeeStatusID;
                await this.UpdateEmployeeAsync(empl,
                    new EmployeeMessageSpecification().ToSuccessUpdateMessage(),
                    new EmployeeMessageSpecification().ToFailUpdateMessage());

                await kernel.Get<IEmployeeDismissService>().CreateEmployeeDismissAsync(
                      new EmployeeDismissDTO()
                      {
                          EmployeeId = IdEmployeeDto,
                          EmploymentDate = DateTime.Now
                      },
                      new EmployeeDismissMessageSpecification().ToSuccessCreateMessage(),
                      new EmployeeDismissMessageSpecification().ToFailCreateMessage());
               return MessageSuccess;
            }
            else
            {
               return MessageFail;
            }
        }
        public async Task<OperationDetails> DismissEmployeeAsync(string id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            List<EmployeeDismissDTO> listDismEmp =
            await kernel.Get<IEmployeeDismissService>().GetAllEmployeeDismissesByIdEmployeeAsync(id);

            EmployeeDismissDTO DismEmp = listDismEmp.Last();
            EmployeeDTO empl = await GetEmployeeByIdAsync(id);
            if (DismEmp.DismissDate==null && empl!=null)
            {
                empl.EmployeeStatusID = (await kernel.Get<IEmployeeStatusService>().GetEmployeeStatusByParamsAsync(Status=>Status.EmployeeStatusName == "Dismiss")).EmployeeStatusID;
                await this.UpdateEmployeeAsync(empl,
                    new EmployeeMessageSpecification().ToSuccessUpdateMessage(),
                    new EmployeeMessageSpecification().ToFailUpdateMessage());
                DismEmp.DismissDate = DateTime.Now;
                await kernel.Get<IEmployeeDismissService>().UpdateEmployeeDismissAsync(DismEmp,
                    new EmployeeDismissMessageSpecification().ToSuccessUpdateMessage(),
                    new EmployeeDismissMessageSpecification().ToFailUpdateMessage());
                return MessageSuccess;
            }
             return MessageFail;
        }

        public async Task<OperationDetails> UpdateEmployeeAsync(EmployeeDTO employeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            string idEmployeeDto = employeeDto.PersonId;
            return await service.UpdateItemAsync(employeeDto,
                idEmployeeDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<EmployeeViewDTO>> FilterEmployeeAsync(EmployeeFilterModel employeeFilter)
        {
            List<EmployeeViewDTO> list = await this.GetAllEmployeesViewAsync();

            if (employeeFilter.Name != "" && employeeFilter.Surname == "" && employeeFilter.Patronumic == "")
                list = list.Where(x => x.Person.Name == employeeFilter.Name
                                  || x.Person.Surname == employeeFilter.Name
                                  || x.Person.Patronumic == employeeFilter.Name).ToList();

            if (employeeFilter.Name != "" && employeeFilter.Surname != "" && employeeFilter.Patronumic == "")
                list = list.Where(x => x.Person.Name == employeeFilter.Name && x.Person.Surname == employeeFilter.Surname
                                    || x.Person.Surname == employeeFilter.Name && x.Person.Name == employeeFilter.Surname
                                    || x.Person.Name == employeeFilter.Name && x.Person.Patronumic == employeeFilter.Surname).ToList();

            if (employeeFilter.Name != null && employeeFilter.Surname != null && employeeFilter.Patronumic != null 
                && employeeFilter.Name != "" && employeeFilter.Surname != "" && employeeFilter.Patronumic != "")
                list = list.Where(x => x.Person.Name == employeeFilter.Name
                                    && x.Person.Surname == employeeFilter.Surname
                                    && x.Person.Name == employeeFilter.Patronumic).ToList();

            if (employeeFilter.EmployeePostID != 0) list = list.Where(x => x.Person.EmployeePostID == employeeFilter.EmployeePostID).ToList();
            return list;
        }
    }
}
