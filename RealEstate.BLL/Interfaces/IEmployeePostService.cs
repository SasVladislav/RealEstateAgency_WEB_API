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
    public interface IEmployeePostService : IDisposable
    {
        Task<List<EmployeePostDTO>> GetAllEmployeePostsAsync(Expression<Func<EmployeePostDTO, bool>> where = null);
        Task<EmployeePostDTO> GetEmployeePostByParamsAsync(Expression<Func<EmployeePostDTO, bool>> where);
        Task<EmployeePostDTO> GetEmployeePostByIdAsync(int id);
        Task<OperationDetails> CreateEmployeePostAsync(EmployeePostDTO employeePostDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteEmployeePostAsync(int id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateEmployeePostAsync(EmployeePostDTO employeePostDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<EmployeePostDTO>> FilterEmployeePostAsync(EmployeePostFilterModel employeePostFilter);
    }
}
