using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class AddressRegion
    {
        public int AddressRegionID { get; set; }
        public string AddressRegionName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
