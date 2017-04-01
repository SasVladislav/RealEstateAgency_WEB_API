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
    public class EmployeePostService : IEmployeePostService
    {
        IRepository<EmployeePost, int> repository;
        IServiceT<EmployeePost, EmployeePostDTO, int> service;
        public EmployeePostService(IRepository<EmployeePost, int> repository,
                                   IServiceT<EmployeePost, EmployeePostDTO, int> service)
        {
            this.repository = repository;
            this.service = service;
        }

        public async Task<List<EmployeePostDTO>> GetAllEmployeePostsAsync(Expression<Func<EmployeePostDTO, bool>> where = null)
        {
            return await service.GetAllItemsAsync();
        }

        public async Task<EmployeePostDTO> GetEmployeePostByParamsAsync(Expression<Func<EmployeePostDTO, bool>> where)
        {
            return await service.GetItemByParamsAsync(where);
        }

        public async Task<EmployeePostDTO> GetEmployeePostByIdAsync(int id)
        {
            return await service.GetItemByIdAsync(id);
        }

        public async Task<OperationDetails> CreateEmployeePostAsync(EmployeePostDTO employeePostDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return (await service.CreateItemAsync(employeePostDto,
                new EmployeePostEquelSpecification(employeePostDto).ToExpression(),
                MessageSuccess,
                MessageFail)).Item1;
        }

        public async Task<OperationDetails> DeleteEmployeePostAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            return await service.DeleteItemAsync(id,
                MessageSuccess,
                MessageFail);
        }

        public async Task<OperationDetails> UpdateEmployeePostAsync(EmployeePostDTO employeePostDto, OperationDetails MessageSuccess, OperationDetails MessageFail)
        {
            int idPostDto = employeePostDto.EmployeePostID;
            return await service.UpdateItemAsync(employeePostDto,
                idPostDto,
                MessageSuccess,
                MessageFail);
        }
        public void Dispose()
        {
            repository.Dispose();
        }

        public async Task<List<EmployeePostDTO>> FilterEmployeePostAsync(EmployeePostFilterModel employeePostFilter)
        {
            List<EmployeePostDTO> list = await this.GetAllEmployeePostsAsync();
            if (employeePostFilter.EmployeePostID != null) list = list.Where(emp => emp.EmployeePostID == employeePostFilter.EmployeePostID).ToList();
            if (employeePostFilter.EmployeePostName != null) list = list.Where(emp => emp.EmployeePostName == employeePostFilter.EmployeePostName).ToList();
            if (employeePostFilter.EmployeePostSalary != null) list = list.Where(emp => emp.EmployeePostSalary == employeePostFilter.EmployeePostSalary).ToList();
            //if (employeePostFilter.BeginEmployeePostSalary != null) list = list.Where(emp => emp.PostDto == employeePostFilter.EmployeePostSalary).ToList();
            // if (employeePostFilter.EndEmployeePostSalary != null) list = list.Where(emp => emp.PostDto == employeePostFilter.EmployeePostSalary).ToList();
            return list;
        }
    }
}
