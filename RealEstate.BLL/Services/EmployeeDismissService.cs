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
    public class EmployeeDismissService : IEmployeeDismissService
    {
        IRepository<EmployeeDismiss, int> repository;
        IRepository<Employee, string> Employeerepository;
        IServiceT<EmployeeDismiss, EmployeeDismissDTO, int> service;
        public EmployeeDismissService(IRepository<EmployeeDismiss, int> repository, IRepository<Employee, string> Employeerepository,
                                         IServiceT<EmployeeDismiss, EmployeeDismissDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
            this.Employeerepository = Employeerepository;
        }
        
        //удаление всех записей с указаным пользователей

        public async Task<List<EmployeeDismissDTO>> GetAllEmployeeDismissesByIdEmployeeAsync(string IdEml=null)
        {
            return await service.GetAllItemsAsync(emp => emp.EmployeeId == IdEml);
        }

        public async Task<List<EmployeeDismissDTO>> GetAllEmployeeDismissesAsync(Expression<Func<EmployeeDismissDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }

        public async Task<EmployeeDismissDTO> GetEmployeeDismissByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<EmployeeDismissDTO> GetEmployeeDismissByParamsAsync(Expression<Func<EmployeeDismissDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<OperationDetails> CreateEmployeeDismissAsync(EmployeeDismissDTO employeeDismissDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(employeeDismissDto,
                new EmployeeDismissEquelSpecification(employeeDismissDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;          
        }

        public async Task<OperationDetails> DeleteEmployeeDismissAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateEmployeeDismissAsync(EmployeeDismissDTO employeeDismissDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idDismissDto = employeeDismissDto.EmployeeDismissId;
            return await service.UpdateItemAsync(employeeDismissDto,
                idDismissDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<EmployeeDismissDTO>> FilterEmployeeDismissAsync(EmployeeDismissFilterModel employeeDismissFilter)
        {
            List<EmployeeDismissDTO> list = await this.GetAllEmployeeDismissesAsync();
            if (employeeDismissFilter.EmployeeId != null) list = list.Where(emp => emp.EmployeeId == employeeDismissFilter.EmployeeId).ToList();
            if (employeeDismissFilter.EmploymentDate != null) list = list.Where(emp => emp.EmploymentDate == employeeDismissFilter.EmploymentDate).ToList();
            if (employeeDismissFilter.DismissDate != null) list = list.Where(emp => emp.DismissDate == employeeDismissFilter.DismissDate).ToList();
            //if (employeeDismissFilter.BeginEmploymentDate != null) list = list.Where(emp => emp.EmployeePostID == employeeDismissFilter.EmployeePostID).ToList();
            //if (employeeDismissFilter.EndEmploymentDate != null) list = list.Where(emp => emp.EmployeeStatusID == employeeDismissFilter.EmployeeStatusID).ToList();
            //if (employeeDismissFilter.BeginDismissDate != null) list = list.Where(emp => emp.AddressID == employeeDismissFilter.AddressID).ToList();
            //if (employeeDismissFilter.EndDismissDate != null) list = list.Where(emp => emp.StateOnline == employeeDismissFilter.StateOnline).ToList();
            return list;
        }
    }
}
