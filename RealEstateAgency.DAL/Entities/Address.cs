using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public int AddressCityID { get; set; }
        public int AddressRegionID { get; set; }
        public int AddressStreetID { get; set; }       
        public string HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }

        public virtual AddressCity AddressCity { get; set; }
        public virtual AddressRegion AddressRegion { get; set; }
        public virtual AddressStreet AddressStreet { get; set; }

    }
}
