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
    public interface IEmployeeDismissService : IDisposable
    {
        Task<List<EmployeeDismissDTO>> GetAllEmployeeDismissesByIdEmployeeAsync(string IdEml = null);
        Task<List<EmployeeDismissDTO>> GetAllEmployeeDismissesAsync(Expression<Func<EmployeeDismissDTO, bool>> where = null);
        Task<EmployeeDismissDTO> GetEmployeeDismissByIdAsync(int id);
        Task<EmployeeDismissDTO> GetEmployeeDismissByParamsAsync(Expression<Func<EmployeeDismissDTO, bool>> where);
        Task<OperationDetails> CreateEmployeeDismissAsync(EmployeeDismissDTO employeeDismissDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteEmployeeDismissAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateEmployeeDismissAsync(EmployeeDismissDTO employeeDismissDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<EmployeeDismissDTO>> FilterEmployeeDismissAsync(EmployeeDismissFilterModel employeeDismissFilter);
    }
}
