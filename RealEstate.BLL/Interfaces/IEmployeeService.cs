using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync(Expression<Func<EmployeeDTO, bool>> where = null);
        Task<List<EmployeeViewDTO>> GetAllEmployeesViewAsync();
        Task<EmployeeDTO> GetEmployeeByParamsAsync(Expression<Func<EmployeeDTO, bool>> where);
        Task<EmployeeDTO> GetEmployeeByIdAsync(string id);
        Task<OperationDetails> CreateEmployeeAsync(EmployeeDTO employeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> CreateEmployeeViewAsync(EmployeeViewDTO employeeViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> CreateExistEmployeeAsync(string IdEmployeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DismissEmployeeAsync(string id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateEmployeeAsync(EmployeeDTO employeeDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<EmployeeDTO>> FilterEmployeeAsync(EmployeeFilterModel employeeFilter);
    }
}
