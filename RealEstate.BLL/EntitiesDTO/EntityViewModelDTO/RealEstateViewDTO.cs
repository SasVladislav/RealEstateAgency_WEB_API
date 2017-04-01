using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class RealEstateViewDTO
    {
        public RealEstateViewDTO()
        {
            RealEstate = new RealEstateDTO();
            Address = new AddressDTO();
        }
        public RealEstateDTO RealEstate { get; set; }
        public AddressDTO Address { get; set; }
    }
}
