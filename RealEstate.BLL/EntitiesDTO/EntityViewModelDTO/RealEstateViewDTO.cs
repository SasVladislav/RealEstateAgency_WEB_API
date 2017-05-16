using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class RealEstateViewDTO
    {
        public RealEstateViewDTO() : base()
        {
            RealEstate = new RealEstateDTO();
            RealEstateClass = new RealEstateClassDTO();
            RealEstateStatus = new RealEstateStatusDTO();
            RealEstateType = new RealEstateTypeDTO();
            RealEstateTypeWall = new RealEstateTypeWallDTO();
            AddressView = new AddressViewDTO();
        }
        public RealEstateDTO RealEstate { get; set; }
        public RealEstateClassDTO RealEstateClass { get; set; }
        public RealEstateStatusDTO RealEstateStatus { get; set; }
        public RealEstateTypeDTO RealEstateType { get; set; }
        public RealEstateTypeWallDTO RealEstateTypeWall { get; set; }
        public AddressViewDTO AddressView { get; set; }
    }
}
