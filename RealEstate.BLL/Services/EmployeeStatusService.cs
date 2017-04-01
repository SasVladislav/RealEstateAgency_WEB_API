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
    public class EmployeeStatusService : IEmployeeStatusService
    {
        IRepository<EmployeeStatus, int> repository;
        IServiceT<EmployeeStatus, EmployeeStatusDTO, int> service;
        public EmployeeStatusService(IRepository<EmployeeStatus, int> repository,
                                         IServiceT<EmployeeStatus, EmployeeStatusDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<EmployeeStatusDTO>> GetAllEmployeeStatusesAsync(Expression<Func<EmployeeStatusDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync(where);
        }
        public async Task<EmployeeStatusDTO> GetEmployeeStatusByParamsAsync(Expression<Func<EmployeeStatusDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }
        public async Task<EmployeeStatusDTO> GetEmployeeStatusByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<OperationDetails> CreateEmployeeStatusAsync(EmployeeStatusDTO employeeStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(employeeStatusDto,
                new EmployeeStatusEquelSpecification(employeeStatusDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteEmployeeStatusAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateEmployeeStatusAsync(EmployeeStatusDTO employeeStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idStatusDto = employeeStatusDto.EmployeeStatusID;
            return await service.UpdateItemAsync(employeeStatusDto,
                idStatusDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<EmployeeStatusDTO>> FilterEmployeeStatusAsync(EmployeeStatusFilterModel employeeStatusFilter)
        {
            List<EmployeeStatusDTO> list = await this.GetAllEmployeeStatusesAsync();
            if (employeeStatusFilter.EmployeeStatusID != null) list = list.Where(emp => emp.EmployeeStatusID == employeeStatusFilter.EmployeeStatusID).ToList();
            if (employeeStatusFilter.EmployeeStatusName != null) list = list.Where(emp => emp.EmployeeStatusName == employeeStatusFilter.EmployeeStatusName).ToList();
            return list;
        }
    }
}
