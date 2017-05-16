using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.EntitiesDTO.EntityViewModelDTO
{
    public class RealEstateFilterViewDTO
    {
        public RealEstateFilterViewDTO()
        {
            RealEstateFilter = new RealEstateFilterModel();
            AddressFilter = new AddressFilterModel();
        }
        public RealEstateFilterModel RealEstateFilter { get; set; }
        public AddressFilterModel AddressFilter { get; set; }
    }
}
