using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class AddressViewDTO
    {
        public AddressViewDTO()
        {
            Address = new AddressDTO();
            AddressCity = new AddressCityDTO();
            AddressRegion = new AddressRegionDTO();
            AddressStreet = new AddressStreetDTO();
        }
        public AddressDTO Address { get; set; }
        public AddressCityDTO AddressCity { get; set; }
        public AddressRegionDTO AddressRegion { get; set; }
        public AddressStreetDTO AddressStreet { get; set; }
    }
}
