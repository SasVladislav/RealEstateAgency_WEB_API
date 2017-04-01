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

            Parallel.ForEach(listEmployees, item =>
             {
                 listEmployeeView.Add(
                                  new EmployeeViewDTO
                                  {
                                      Person = item,
                                      Address = listAddresses
                                                   .Where(a => a.AddressID == item.AddressID)
                                                   .AsParallel()
                                                   .FirstOrDefault(),
                                      Dismisses = listDismiss
                                                   .Where(a => a.EmployeeId == item.PersonId)
                                                   .AsParallel()
                                                   .ToList()
                                  }
                                 );
             });
            return listEmployeeView;
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

        public async Task<List<EmployeeDTO>> FilterEmployeeAsync(EmployeeFilterModel employeeFilter)
        {
            List<EmployeeDTO> list = await this.GetAllEmployeesAsync();
            if (employeeFilter.Name != null) list = list.Where(emp => emp.Name == employeeFilter.Name).ToList();
            if (employeeFilter.Surname != null) list = list.Where(emp => emp.Surname == employeeFilter.Surname).ToList();
            if (employeeFilter.Patronumic != null) list = list.Where(emp => emp.Patronumic == employeeFilter.Patronumic).ToList();
            if (employeeFilter.EmployeePostID != null) list = list.Where(emp => emp.EmployeePostID == employeeFilter.EmployeePostID).ToList();
            if (employeeFilter.EmployeeStatusID != null) list = list.Where(emp => emp.EmployeeStatusID == employeeFilter.EmployeeStatusID).ToList();
            if (employeeFilter.AddressID != null) list = list.Where(emp => emp.AddressID == employeeFilter.AddressID).ToList();
            if (employeeFilter.StateOnline != null) list = list.Where(emp => emp.StateOnline == employeeFilter.StateOnline).ToList();
            if (employeeFilter.PhoneNumber != null) list = list.Where(emp => emp.PhoneNumber == employeeFilter.PhoneNumber).ToList();
            //if (employeeFilter.Email != null) list = list.Where(emp => emp.Email == employeeFilter.Email).ToList();
            return list;
        }
    }
}
