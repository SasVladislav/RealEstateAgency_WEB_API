using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IEmployeeStatusService : IDisposable
    {
        Task<List<EmployeeStatusDTO>> GetAllEmployeeStatusesAsync(Expression<Func<EmployeeStatusDTO, bool>> where = null);
        Task<EmployeeStatusDTO> GetEmployeeStatusByIdAsync(int id);
        Task<EmployeeStatusDTO> GetEmployeeStatusByParamsAsync(Expression<Func<EmployeeStatusDTO, bool>> where);
        Task<OperationDetails> CreateEmployeeStatusAsync(EmployeeStatusDTO employeeStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteEmployeeStatusAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateEmployeeStatusAsync(EmployeeStatusDTO employeeStatusDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<EmployeeStatusDTO>> FilterEmployeeStatusAsync(EmployeeStatusFilterModel employeeStatusFilter);
    }
}
