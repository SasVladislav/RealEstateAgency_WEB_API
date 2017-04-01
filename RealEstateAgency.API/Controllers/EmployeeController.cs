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
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        IEmployeeService employeeService;
        IEmployeeDismissService employeeDismissService;
        IEmployeePostService employeePostService;
        IEmployeeStatusService employeeStatusService;
        public EmployeeController(IEmployeeService employeeService, IEmployeeDismissService employeeDismissService,
                          IEmployeePostService employeePostService, IEmployeeStatusService employeeStatusService)
        {
            this.employeeService = employeeService;
            this.employeeDismissService = employeeDismissService;
            this.employeePostService = employeePostService;
            this.employeeStatusService = employeeStatusService;
        }

        #region Employee
        //-----Employee
        [Route("GetAllEmployees")]
        [HttpGet]
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            return await employeeService.GetAllEmployeesAsync();
        }
        [Route("GetAllEmployeesView")]
        [HttpGet]
        public async Task<List<EmployeeViewDTO>> GetAllEmployeesView()
        {
            return await employeeService.GetAllEmployeesViewAsync() ;
        }
        [Route("GetEmployee")]
        [HttpPost]
        public async Task<EmployeeDTO> GetEmployee(SendIDToWebApiDTO SendID)
        {
            string idEmployee = SendID.IdString;
            return await employeeService.GetEmployeeByIdAsync(idEmployee);
        }
        [Route("CreateEmployee")]
        [HttpPost]
        public async Task<OperationDetails> CreateEmployee(EmployeeDTO EmployeeDto)
        {
            return await employeeService.CreateEmployeeAsync(EmployeeDto,
                new EmployeeMessageSpecification().ToSuccessCreateMessage(),
                new EmployeeMessageSpecification().ToFailCreateMessage());
        }
        [Route("CreateEmployeeView")]
        [HttpPost]
        public async Task<OperationDetails> CreateEmployeeView(EmployeeViewDTO EmployeeViewDto)
        {
            return await employeeService.CreateEmployeeViewAsync(EmployeeViewDto,
                new EmployeeMessageSpecification().ToSuccessCreateMessage(),
                new EmployeeMessageSpecification().ToFailCreateMessage());
        }
        [Route("CreateExistEmployee")]
        [HttpPost]
        public async Task<OperationDetails> CreateExistEmployee(SendIDToWebApiDTO SendID)
        {
            string idEmployee = SendID.IdString;
            return await employeeService.CreateExistEmployeeAsync(idEmployee,
                new EmployeeMessageSpecification().ToSuccessCreateExistMessage(),
                new EmployeeMessageSpecification().ToFailCreateExistMessage());
        }
        [Route("DismissEmployee")]
        [HttpPost]
        public async Task<OperationDetails> DismissEmployee(SendIDToWebApiDTO SendID)
        {
            string idEmployee = SendID.IdString;
            return await employeeService.DismissEmployeeAsync(idEmployee,
                new EmployeeMessageSpecification().ToSuccessDeleteMessage(),
                new EmployeeMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateEmployee")]
        [HttpPost]
        public async Task<OperationDetails> UpdateEmployee(EmployeeDTO EmployeeDto)
        {
            return await employeeService.UpdateEmployeeAsync(EmployeeDto,
                    new EmployeeMessageSpecification().ToSuccessUpdateMessage(),
                    new EmployeeMessageSpecification().ToFailUpdateMessage());
        }

        [Route("FilterEmployee")]
        [HttpPost]
        public async Task<List<EmployeeDTO>> FilterEmployee(EmployeeFilterModel EmployeeDto)
        {
            return await employeeService.FilterEmployeeAsync(EmployeeDto);        
        }
        #endregion

        #region EmployeeDismiss
        //-----EmployeePost
        [Route("GetAllDismiss")]
        [HttpGet]
        public async Task<List<EmployeeDismissDTO>> GetAllDismisses()
        {
            return await employeeDismissService.GetAllEmployeeDismissesAsync();
        }
        [Route("GetAllDismissesByEmployee")]
        [HttpPost]
        public async Task<List<EmployeeDismissDTO>> GetAllDismissesByEmployee(SendIDToWebApiDTO SendID)
        {
            string idEmployee = SendID.IdString;
            return await employeeDismissService.GetAllEmployeeDismissesAsync(empl=>empl.EmployeeId== idEmployee);
        }
        [Route("GetDismiss")]
        [HttpPost]
        public async Task<EmployeeDismissDTO> GetDismiss(SendIDToWebApiDTO SendID)
        {
            int idDismiss = SendID.IdInt;
            return await employeeDismissService.GetEmployeeDismissByIdAsync(idDismiss);
        }
        [Route("CreateDismiss")]
        [HttpPost]
        public async Task<OperationDetails> CreateDismiss(EmployeeDismissDTO DismissDto)
        {
            return await employeeDismissService.CreateEmployeeDismissAsync(DismissDto,
               new EmployeeDismissMessageSpecification().ToSuccessCreateMessage(),
               new EmployeeDismissMessageSpecification().ToFailCreateMessage());
        }
        [Route("DeleteDismiss")]
        [HttpPost]
        public async Task<OperationDetails> DeleteDismiss(SendIDToWebApiDTO SendID)
        {
            int idDismiss = SendID.IdInt;
            return await employeeDismissService.DeleteEmployeeDismissAsync(idDismiss,
                new EmployeeDismissMessageSpecification().ToSuccessDeleteMessage(),
                new EmployeeDismissMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateDismiss")]
        [HttpPost]
        public async Task<OperationDetails> UpdateDismiss(EmployeeDismissDTO DismissDto)
        {
            return await employeeDismissService.UpdateEmployeeDismissAsync(DismissDto,
                    new EmployeeDismissMessageSpecification().ToSuccessUpdateMessage(),
                    new EmployeeDismissMessageSpecification().ToFailUpdateMessage());
        }

        [Route("FilterEmployeeDismiss")]
        [HttpPost]
        public async Task<List<EmployeeDismissDTO>> FilterEmployeeDismiss(EmployeeDismissFilterModel DismissDto)
        {
            return await employeeDismissService.FilterEmployeeDismissAsync(DismissDto);
        }
        #endregion

        #region EmployeePost
        //-----EmployeePost
        [Route("GetAllPosts")]
        [HttpGet]
        public async Task<List<EmployeePostDTO>> GetAllPosts()
        {
            return await employeePostService.GetAllEmployeePostsAsync();
        }
        [Route("GetPost")]
        [HttpPost]
        public async Task<EmployeePostDTO> GetPost(SendIDToWebApiDTO SendID)
        {
            int idPost = SendID.IdInt;
            return await employeePostService.GetEmployeePostByIdAsync(idPost);
        }
        [Route("CreatePost")]
        [HttpPost]
        public async Task<OperationDetails> CreatePost(EmployeePostDTO PostDto)
        {
            return await employeePostService.CreateEmployeePostAsync(PostDto,
                new EmployeePostMessageSpecification(PostDto).ToSuccessCreateMessage(),
                new EmployeePostMessageSpecification(PostDto).ToFailCreateMessage());
        }
        [Route("DeletePost")]
        [HttpPost]
        public async Task<OperationDetails> DeletePost(SendIDToWebApiDTO SendID)
        {
            int idPost = SendID.IdInt;
            return await employeePostService.DeleteEmployeePostAsync(idPost,
                new EmployeePostMessageSpecification().ToSuccessDeleteMessage(),
                new EmployeePostMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdatePost")]
        [HttpPost]
        public async Task<OperationDetails> UpdatePost(EmployeePostDTO PostDto)
        {
            return await employeePostService.UpdateEmployeePostAsync(PostDto,
                    new EmployeePostMessageSpecification(PostDto).ToSuccessUpdateMessage(),
                    new EmployeePostMessageSpecification(PostDto).ToFailUpdateMessage());
        }
        [Route("FilterEmployeePost")]
        [HttpPost]
        public async Task<List<EmployeePostDTO>> FilterEmployeePost(EmployeePostFilterModel PostDto)
        {
            return await employeePostService.FilterEmployeePostAsync(PostDto);            
        }
        #endregion

        #region EmployeeStatus
        //-----EmployeeStatus
        [Route("GetAllStatuses")]
        [HttpGet]
        public async Task<List<EmployeeStatusDTO>> GetAllStatuses()
        {
            return await employeeStatusService.GetAllEmployeeStatusesAsync();
        }
        [Route("GetStatus")]
        [HttpPost]
        public async Task<EmployeeStatusDTO> GetStatus(SendIDToWebApiDTO SendID)
        {
            int idStatus = SendID.IdInt;
            return await employeeStatusService.GetEmployeeStatusByIdAsync(idStatus);
        }
        [Route("CreateStatus")]
        [HttpPost]
        public async Task<OperationDetails> CreateStatus(EmployeeStatusDTO StatusDto)
        {
            return await employeeStatusService.CreateEmployeeStatusAsync(StatusDto,
                new EmployeeStatusMessageSpecification(StatusDto).ToSuccessCreateMessage(),
                new EmployeeStatusMessageSpecification(StatusDto).ToFailCreateMessage());
        }
        [Route("DeleteStatus")]
        [HttpPost]
        public async Task<OperationDetails> DeleteStatus(SendIDToWebApiDTO SendID)
        {
            int idStatus = SendID.IdInt;
            return await employeeStatusService.DeleteEmployeeStatusAsync(idStatus,
                new EmployeeStatusMessageSpecification().ToSuccessDeleteMessage(),
                new EmployeeStatusMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateStatus")]
        [HttpPost]
        public async Task<OperationDetails> UpdateStatus(EmployeeStatusDTO StatusDto)
        {
            return await employeeStatusService.UpdateEmployeeStatusAsync(StatusDto,
                    new EmployeeStatusMessageSpecification(StatusDto).ToSuccessUpdateMessage(),
                    new EmployeeStatusMessageSpecification(StatusDto).ToFailUpdateMessage());
        }
        [Route("FilterEmployeeStatus")]
        [HttpPost]
        public async Task<List<EmployeeStatusDTO>> FilterEmployeeStatus(EmployeeStatusFilterModel StatusDto)
        {
            return await employeeStatusService.FilterEmployeeStatusAsync(StatusDto);
        }
        #endregion
    }
}
