using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using System.Security.Claims;
using System.Linq.Expressions;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;

namespace RealEstateAgency.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<List<UserDTO>> GetAllUsersAsync(Expression<Func<UserDTO, bool>> where = null);
        Task<List<UserViewDTO>> GetAllUsersViewAsync(Expression<Func<UserDTO, bool>> where = null);
        Task<UserDTO> GetUserByParamsAsync(Expression<Func<UserDTO, bool>> where);
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<OperationDetails> CreateUserAsync(UserDTO userDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> CreateUserViewAsync(UserViewDTO userViewDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> DeleteUserAsync(string id, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<OperationDetails> UpdateUserAsync(UserDTO userDto, OperationDetails MessageSuccess, OperationDetails MessageFail);
        Task<List<UserViewDTO>> FilterUsersFullNameAsync(UserFilterModel userFilterModel);
        Task<List<UserDTO>> FilterUserAsync(UserFilterModel userFilter);
    }
}
