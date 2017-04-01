using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RealEstateAgency.API.Controllers
{
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        #region User
        //-----User
        [Route("GetAllUsers")]
        [HttpGet]
        public async Task<List<UserDTO>> GetAllUsers()
        {
            return await userService.GetAllUsersAsync();
        }
        [Route("GetAllUsersView")]
        [HttpGet]
        public async Task<List<UserViewDTO>> GetAllUsersView()
        {
            return await userService.GetAllUsersViewAsync();
        }
        [Route("GetUser")]
        [HttpPost]
        public async Task<UserDTO> GetUser(SendIDToWebApiDTO SendID)
        {
            string idUser = SendID.IdString;
            return await userService.GetUserByIdAsync(idUser);
        }
        [Route("CreateUser")]
        [HttpPost]
        public async Task<OperationDetails> CreateUser(UserDTO UserDto)
        {
            return await userService.CreateUserAsync(UserDto,
                new UserMessageSpecification().ToSuccessCreateMessage(),
                new UserMessageSpecification().ToFailCreateMessage());
        }
        [Route("CreateUserViewAsync")]
        [HttpPost]
        public async Task<OperationDetails> CreateUserViewAsync(UserViewDTO userViewDto)
        {
            return await userService.CreateUserViewAsync(userViewDto,
                new UserMessageSpecification().ToSuccessCreateMessage(),
                new UserMessageSpecification().ToFailCreateMessage());
        }
        [Route("DeleteUser")]
        [HttpPost]
        public async Task<OperationDetails> DeleteUser(SendIDToWebApiDTO SendID)
        {
            string idUser = SendID.IdString;
            return await userService.DeleteUserAsync(idUser,
                new UserMessageSpecification().ToSuccessDeleteMessage(),
                new UserMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateUser")]
        [HttpPost]
        public async Task<OperationDetails> UpdateUser(UserDTO UserDto)
        {
            return await userService.UpdateUserAsync(UserDto,
                    new UserMessageSpecification().ToSuccessUpdateMessage(),
                    new UserMessageSpecification().ToFailUpdateMessage());
        }
        
        [Route("FilterFullNameUsers")]
        [HttpPost]
        public async Task<List<UserViewDTO>> FilterFullNameUsers(UserFilterModel UserDto)
        {
            return await userService.FilterUsersFullNameAsync(UserDto);
        }
        [Route("FilterUser")]
        [HttpPost]
        public async Task<List<UserDTO>> FilterUser(UserFilterModel UserDto)
        {
            return await userService.FilterUserAsync(UserDto);
        }
        #endregion
    }
}
