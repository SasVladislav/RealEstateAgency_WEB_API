using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class AddressFilterModel
    {
        public int? AddressID { get; set; }
        public int? AddressCityID { get; set; }
        public int? AddressRegionID { get; set; }
        public int? AddressStreetID { get; set; }
        public string HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
}
