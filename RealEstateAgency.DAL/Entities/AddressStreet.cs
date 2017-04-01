using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class AddressStreet
    {
        public int AddressStreetID { get; set; }
        public string AddressStreetName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
