using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.Specifications;
using RealEstateAgency.BLL.Interfaces;

namespace RealEstateAgency.API.Controllers
{
    [RoutePrefix("Address")]
    public class AddressController : ApiController
    {
        
        IAddressService addressService;
        IAddressCityService addressCityService;
        IAddressStreetService addressStreetService;
        IAddressRegionService addressRegionService;
        public AddressController(IAddressService addressService, IAddressCityService addressCityService,
                     IAddressStreetService addressStreetService, IAddressRegionService addressRegionService)
        {
            this.addressService = addressService;
            this.addressCityService = addressCityService;
            this.addressStreetService = addressStreetService;
            this.addressRegionService = addressRegionService;
        }

        #region Address
        //-----Address
        [Route("GetAllAddresses")]
        [HttpGet]
        public async Task<List<AddressDTO>> GetAllAddresses()
        {
            return await addressService.GetAllAddressesAsync(); 
        }
        [Route("GetAddress")]
        [HttpPost]
        public async Task<AddressDTO> GetAddress(SendIDToWebApiDTO SendID)
        {
            int idAddress = SendID.IdInt;
            return await addressService.GetAddressByIdAsync(idAddress);
        }
        [Route("CreateAddress")]
        [HttpPost]
        public async Task<OperationDetails> CreateAddress(AddressDTO addressDto)
        {
            return await addressService.CreateAddressAsync(addressDto,
                new AddressMessageSpecification().ToSuccessCreateMessage(),
                new AddressMessageSpecification().ToFailCreateMessage());
        }
        [Route("DeleteAddress")]
        [HttpPost]
        public async Task<OperationDetails> DeleteAddress(SendIDToWebApiDTO SendID)
        {
            int idAddress = SendID.IdInt;
            return await addressService.DeleteAddressAsync(idAddress,
                new AddressMessageSpecification().ToSuccessDeleteMessage(),
                new AddressMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateAddress")]
        [HttpPost]
        public async Task<OperationDetails> UpdateAddress(AddressDTO addressDto)
        {
            return await addressService.UpdateAddressAsync(addressDto,
                new AddressMessageSpecification().ToSuccessUpdateMessage(),
                new AddressMessageSpecification().ToFailUpdateMessage());
        }
        [Route("FilterAddress")]
        [HttpPost]
        public async Task<List<AddressDTO>> FilterAddress(AddressFilterModel addressDto)
        {
           return await addressService.FilterAddressAsync(addressDto);
        }
        #endregion

        #region City       
        //-----City
        [Route("GetAllCities")]
        [HttpGet]
        public async Task<List<AddressCityDTO>> GetAllCities()
        {
            return await addressCityService.GetAllAddressCitiesAsync();
        }
        [Route("GetCity")]
        [HttpPost]
        public async Task<AddressCityDTO> GetCity(SendIDToWebApiDTO SendID)
        {
            int idCity = SendID.IdInt;
            return await addressCityService.GetAddressCityByIdAsync(idCity);
        }
        [Route("CreateCity")]
        [HttpPost]
        public async Task<OperationDetails> CreateCity(AddressCityDTO CityDto)
        {
            return await addressCityService.CreateAddressCityAsync(CityDto,
                new AddressCityMessageSpecification(CityDto).ToSuccessCreateMessage(),
                new AddressCityMessageSpecification(CityDto).ToFailCreateMessage());
        }
        [Route("DeleteCity")]
        [HttpPost]
        public async Task<OperationDetails> DeleteCity(SendIDToWebApiDTO SendID)
        {
            int idCity = SendID.IdInt;
            return await addressCityService.DeleteAddressCityAsync(idCity,
                new AddressCityMessageSpecification().ToSuccessDeleteMessage(),
                new AddressCityMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateCity")]
        [HttpPost]
        public async Task<OperationDetails> UpdateCity(AddressCityDTO CityDto)
        {
            return await addressCityService.UpdateAddressCityAsync(CityDto,
                new AddressCityMessageSpecification(CityDto).ToSuccessUpdateMessage(),
                new AddressCityMessageSpecification(CityDto).ToFailUpdateMessage());
        }
        [Route("FilterCity")]
        [HttpPost]
        public async Task<List<AddressCityDTO>> FilterCity(AddressCityFilterModel CityDto)
        {
            return await addressCityService.FilterAddressCityAsync(CityDto);            
        }
        #endregion

        #region Region

        //--------Region
        [Route("AllRegions")]
        [HttpGet]
        public async Task<List<AddressRegionDTO>> GetAllRegions()
        {
            return await addressRegionService.GetAllAddressRegionsAsync();
        }
        [Route("GetRegion")]
        [HttpPost]
        public async Task<AddressRegionDTO> GetRegion(SendIDToWebApiDTO SendID)
        {
            int idRegion = SendID.IdInt;
            return await addressRegionService.GetAddressRegionByIdAsync(idRegion);
        }
        [Route("CreateRegion")]
        [HttpPost]
        public async Task<OperationDetails> CreateRegion(AddressRegionDTO RegionDto)
        {
            return await addressRegionService.CreateAddressRegionAsync(RegionDto,
                new AddressRegionMessageSpecification(RegionDto).ToSuccessCreateMessage(),
                new AddressRegionMessageSpecification(RegionDto).ToFailCreateMessage());
        }
        [Route("DeleteRegion")]
        [HttpPost]
        public async Task<OperationDetails> DeleteRegion(SendIDToWebApiDTO SendID)
        {
            int idRegion = SendID.IdInt;
            return await addressRegionService.DeleteAddressRegionAsync(idRegion,
                new AddressRegionMessageSpecification().ToSuccessDeleteMessage(),
                new AddressRegionMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateRegion")]
        [HttpPost]
        public async Task<OperationDetails> UpdateRegion(AddressRegionDTO RegionDto)
        {
            return await addressRegionService.UpdateAddressRegionAsync(RegionDto,
                    new AddressRegionMessageSpecification(RegionDto).ToSuccessUpdateMessage(),
                    new AddressRegionMessageSpecification(RegionDto).ToFailUpdateMessage());
        }
        [Route("FilterRegion")]
        [HttpPost]
        public async Task<List<AddressRegionDTO>> FilterRegion(AddressRegionFilterModel RegionDto)
        {
            return await addressRegionService.FilterAddressRegionAsync(RegionDto);          
        }
        #endregion

        #region Street

        //Street
        [Route("GetAllStreets")]
        [HttpGet]
        public async Task<List<AddressStreetDTO>> GetAllStreets()
        {
            return await addressStreetService.GetAllAddressStreetsAsync();
        }
        [Route("GetStreet")]
        [HttpPost]
        public async Task<AddressStreetDTO> GetStreet(SendIDToWebApiDTO SendID)
        {
            int idStreet = SendID.IdInt;
            return await addressStreetService.GetAddressStreetByIdAsync(idStreet);
        }
        [Route("CreateStreet")]
        [HttpPost]
        public async Task<OperationDetails> CreateStreet(AddressStreetDTO StreetDto)
        {
            return await addressStreetService.CreateAddressStreetAsync(StreetDto,
                new AddressStreetMessageSpecification(StreetDto).ToSuccessCreateMessage(),
                new AddressStreetMessageSpecification(StreetDto).ToFailCreateMessage());
        }
        [Route("DeleteStreet")]
        [HttpPost]
        public async Task<OperationDetails> DeleteStreet(SendIDToWebApiDTO SendID)
        {
            int idStreet = SendID.IdInt;
            return await addressStreetService.DeleteAddressStreetAsync(idStreet,
                new AddressStreetMessageSpecification().ToSuccessDeleteMessage(),
                new AddressStreetMessageSpecification().ToFailDeleteMessage());
        }
        [Route("UpdateStreet")]
        [HttpPost]
        public async Task<OperationDetails> UpdateStreet(AddressStreetDTO StreetDto)
        {
            return await addressStreetService.UpdateAddressStreetAsync(StreetDto,
                    new AddressStreetMessageSpecification(StreetDto).ToSuccessUpdateMessage(),
                    new AddressStreetMessageSpecification(StreetDto).ToFailUpdateMessage());
        }

        [Route("FilterStreet")]
        [HttpPost]
        public async Task<List<AddressStreetDTO>> FilterStreet(AddressStreetFilterModel StreetDto)
        {
            return await addressStreetService.FilterAddressStreetAsync(StreetDto);
        }
        #endregion

    }
}
