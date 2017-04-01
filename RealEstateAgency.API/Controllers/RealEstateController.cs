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
    [RoutePrefix("RealEstate")]
    public class RealEstateController : ApiController
    {
        IRealEstateService realEstateService;
        IRealEstateClassService realEstateClassService;
        IRealEstateStatusService realEstateStatusService;
        IRealEstateTypeService realEstateTypeService;
        IRealEstateTypeWallService realEstateTypeWallService;
        public RealEstateController(IRealEstateService realEstateService, IRealEstateClassService realEstateClassService,
                        IRealEstateStatusService realEstateStatusService, IRealEstateTypeService realEstateTypeService,
                        IRealEstateTypeWallService realEstateTypeWallService)
        {
            this.realEstateService = realEstateService;
            this.realEstateClassService = realEstateClassService;
            this.realEstateStatusService = realEstateStatusService;
            this.realEstateTypeService = realEstateTypeService;
            this.realEstateTypeWallService = realEstateTypeWallService;
        }

        #region RealEstate
        //-----RealEstate
        [Route("GetAllRealEstates")]
        [HttpGet]
        public async Task<List<RealEstateDTO>> GetAllRealEstates()
        {
            return await realEstateService.GetAllRealEstatesAsync();
        }
        [Route("GetAllRealEstatesView")]
        [HttpGet]
        public async Task<List<RealEstateViewDTO>> GetAllRealEstatesView()
        {
            return await realEstateService.GetAllRealEstatesViewAsync();
        }
        [Route("GetRealEstate")]
        [HttpPost]
        public async Task<RealEstateDTO> GetRealEstate(SendIDToWebApiDTO SendID)
        {
            int idRealEstate = SendID.IdInt;
            return await realEstateService.GetRealEstateByIdAsync(idRealEstate);
        }
        [Route("CreateRealEstate")]
        [HttpPost]
        public async Task<OperationDetails> CreateRealEstate(RealEstateViewDTO RealEstateViewDto)
        {
            return await realEstateService.CreateRealEstateAsync(RealEstateViewDto,
               new RealEstateMessageSpecification().ToSuccessCreateMessage(),
               new RealEstateMessageSpecification().ToFailCreateMessage());
        }
        [Route("DeleteRealEstate")]
        [HttpPost]
        public async Task<OperationDetails> DeleteRealEstate(SendIDToWebApiDTO SendID)
        {
            int idRealEstate = SendID.IdInt;
            return await realEstateService.DeleteRealEstateAsync(idRealEstate,
                new RealEstateMessageSpecification().ToSuccessDeleteMessage(),
                new RealEstateMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateRealEstate")]
        [HttpPost]
        public async Task<OperationDetails> UpdateRealEstate(RealEstateDTO RealEstateDto)
        {
            return await realEstateService.UpdateRealEstateAsync(RealEstateDto,
                new RealEstateMessageSpecification().ToSuccessUpdateMessage(),
                new RealEstateMessageSpecification().ToFailUpdateMessage());
        }
        [Route("FilterRealEstate")]
        [HttpPost]
        public async Task<List<RealEstateDTO>> FilterRealEstate(RealEstateFilterModel RealEstateDto)
        {
            return await realEstateService.FilterRealEstateAsync(RealEstateDto);            
        }
        [Route("FilterRealEstateView")]
        [HttpPost]
        public async Task<List<RealEstateViewDTO>> FilterRealEstateView(
            RealEstateFilterViewDTO realEstateFilterView)
        {
            return await realEstateService.GetAllFilterRealEstatesViewAsync(realEstateFilterView);
        }
        #endregion

        #region Class
        //-----Class
        [Route("GetAllClasses")]
        [HttpGet]
        public async Task<List<RealEstateClassDTO>> GetAllClasses()
        {
            return await realEstateClassService.GetAllRealEstateClassesAsync();
        }
        [Route("GetClass")]
        [HttpPost]
        public async Task<RealEstateClassDTO> GetClass(SendIDToWebApiDTO SendID)
        {
            int idClass = SendID.IdInt;
            return await realEstateClassService.GetRealEstateClassByIdAsync(idClass);
        }
        [Route("CreateClass")]
        [HttpPost]
        public async Task<OperationDetails> CreateClass(RealEstateClassDTO ClassDto)
        {
            return await realEstateClassService.CreateRealEstateClassAsync(ClassDto,
                new RealEstateClassMessageSpecification(ClassDto).ToSuccessCreateMessage(),
                new RealEstateClassMessageSpecification(ClassDto).ToFailCreateMessage());
        }
        [Route("DeleteClass")]
        [HttpPost]
        public async Task<OperationDetails> DeleteClass(SendIDToWebApiDTO SendID)
        {
            int idClass = SendID.IdInt;
            return await realEstateClassService.DeleteRealEstateClassAsync(idClass,
                new RealEstateClassMessageSpecification().ToSuccessDeleteMessage(),
                new RealEstateClassMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateClass")]
        [HttpPost]
        public async Task<OperationDetails> UpdateClass(RealEstateClassDTO ClassDto)
        {
            return await realEstateClassService.UpdateRealEstateClassAsync(ClassDto,
                    new RealEstateClassMessageSpecification(ClassDto).ToSuccessUpdateMessage(),
                    new RealEstateClassMessageSpecification(ClassDto).ToFailUpdateMessage());
        }
        [Route("FilterClass")]
        [HttpPost]
        public async Task<List<RealEstateClassDTO>> FilterClass(RealEstateClassFilterModel ClassDto)
        {
            return await realEstateClassService.FilterRealEstateClassAsync(ClassDto);
        }
        #endregion

        #region Status
        //-----Status
        [Route("GetAllStatuses")]
        [HttpGet]
        public async Task<List<RealEstateStatusDTO>> GetAllStatuses()
        {
            return await realEstateStatusService.GetAllRealEstateStatusesAsync();
        }
        [Route("GetStatus")]
        [HttpPost]
        public async Task<RealEstateStatusDTO> GetStatus(SendIDToWebApiDTO SendID)
        {
            int idStatus = SendID.IdInt;
            return await realEstateStatusService.GetRealEstateStatusByIdAsync(idStatus);
        }
        [Route("CreateStatus")]
        [HttpPost]
        public async Task<OperationDetails> CreateStatus(RealEstateStatusDTO StatusDto)
        {
            return await realEstateStatusService.CreateRealEstateStatusAsync(StatusDto,
                new RealEstateStatusMessageSpecification(StatusDto).ToSuccessCreateMessage(),
                new RealEstateStatusMessageSpecification(StatusDto).ToFailCreateMessage());
        }
        [Route("DeleteStatus")]
        [HttpPost]
        public async Task<OperationDetails> DeleteStatus(SendIDToWebApiDTO SendID)
        {
            int idStatus = SendID.IdInt;
            return await realEstateStatusService.DeleteRealEstateStatusAsync(idStatus,
                new RealEstateStatusMessageSpecification().ToSuccessDeleteMessage(),
                new RealEstateStatusMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateStatus")]
        [HttpPost]
        public async Task<OperationDetails> UpdateStatus(RealEstateStatusDTO StatusDto)
        {
            return await realEstateStatusService.UpdateRealEstateStatusAsync(StatusDto,
                    new RealEstateStatusMessageSpecification(StatusDto).ToSuccessUpdateMessage(),
                    new RealEstateStatusMessageSpecification(StatusDto).ToFailUpdateMessage());
        }
        [Route("FilterStatus")]
        [HttpPost]
        public async Task<List<RealEstateStatusDTO>> FilterStatus(RealEstateStatusFilterModel StatusDto)
        {
            return await realEstateStatusService.FilterRealEstateStatusAsync(StatusDto);          
        }
        #endregion

        #region Type
        //-----Type
        [Route("GetAllTypes")]
        [HttpGet]
        public async Task<List<RealEstateTypeDTO>> GetAllTypes()
        {
            return await realEstateTypeService.GetAllRealEstateTypesAsync();
        }
        [Route("GetType")]
        [HttpPost]
        public async Task<RealEstateTypeDTO> GetType(SendIDToWebApiDTO SendID)
        {
            int idType = SendID.IdInt;
            return await realEstateTypeService.GetRealEstateTypeByIdAsync(idType);
        }
        [Route("CreateType")]
        [HttpPost]
        public async Task<OperationDetails> CreateType(RealEstateTypeDTO TypeDto)
        {
            return await realEstateTypeService.CreateRealEstateTypeAsync(TypeDto,
                new RealEstateTypeMessageSpecification(TypeDto).ToSuccessCreateMessage(),
                new RealEstateTypeMessageSpecification(TypeDto).ToFailCreateMessage());
        }
        [Route("DeleteType")]
        [HttpPost]
        public async Task<OperationDetails> DeleteType(SendIDToWebApiDTO SendID)
        {
            int idType = SendID.IdInt;
            return await realEstateTypeService.DeleteRealEstateTypeAsync(idType,
                new RealEstateTypeMessageSpecification().ToSuccessDeleteMessage(),
                new RealEstateTypeMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateType")]
        [HttpPost]
        public async Task<OperationDetails> UpdateType(RealEstateTypeDTO TypeDto)
        {
            return await realEstateTypeService.UpdateRealEstateTypeAsync(TypeDto,
                    new RealEstateTypeMessageSpecification(TypeDto).ToSuccessUpdateMessage(),
                    new RealEstateTypeMessageSpecification(TypeDto).ToFailUpdateMessage());
        }
        [Route("FilterType")]
        [HttpPost]
        public async Task<List<RealEstateTypeDTO>> FilterType(RealEstateTypeFilterModel TypeDto)
        {
            return await realEstateTypeService.FilterRealEstateTypeAsync(TypeDto);
        }
        #endregion

        #region TypeWall
        //-----TypeWall
        [Route("GetAllTypeWalls")]
        [HttpGet]
        public async Task<List<RealEstateTypeWallDTO>> GetAllTypeWalls()
        {
            return await realEstateTypeWallService.GetAllRealEstateTypeWallsAsync();
        }
        [Route("GetTypeWall")]
        [HttpPost]
        public async Task<RealEstateTypeWallDTO> GetTypeWall(SendIDToWebApiDTO SendID)
        {
            int idTypeWall = SendID.IdInt;
            return await realEstateTypeWallService.GetRealEstateTypeWallByIdAsync(idTypeWall);
        }
        [Route("CreateTypeWall")]
        [HttpPost]
        public async Task<OperationDetails> CreateTypeWall(RealEstateTypeWallDTO TypeWallDto)
        {
            return await realEstateTypeWallService.CreateRealEstateTypeWallAsync(TypeWallDto,
                new RealEstateTypeWallMessageSpecification(TypeWallDto).ToSuccessCreateMessage(),
                new RealEstateTypeWallMessageSpecification(TypeWallDto).ToFailCreateMessage());
        }
        [Route("DeleteTypeWall")]
        [HttpPost]
        public async Task<OperationDetails> DeleteTypeWall(SendIDToWebApiDTO SendID)
        {
            int idTypeWall = SendID.IdInt;
            return await realEstateTypeWallService.DeleteRealEstateTypeWallAsync(idTypeWall,
                new RealEstateTypeWallMessageSpecification().ToSuccessDeleteMessage(),
                new RealEstateTypeWallMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateTypeWall")]
        [HttpPost]
        public async Task<OperationDetails> UpdateTypeWall(RealEstateTypeWallDTO TypeWallDto)
        {
            return await realEstateTypeWallService.UpdateRealEstateTypeWallAsync(TypeWallDto,
                new RealEstateTypeWallMessageSpecification(TypeWallDto).ToSuccessUpdateMessage(),
                new RealEstateTypeWallMessageSpecification(TypeWallDto).ToFailUpdateMessage());
        }
        [Route("FilterTypeWall")]
        [HttpPost]
        public async Task<List<RealEstateTypeWallDTO>> FilterTypeWall(RealEstateTypeWallFilterModel TypeWallDto)
        {
            return await realEstateTypeWallService.FilterRealEstateTypeWallAsync(TypeWallDto);         
        }
        #endregion
    }
}
