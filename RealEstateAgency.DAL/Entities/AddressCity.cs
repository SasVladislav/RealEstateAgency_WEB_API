using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class AddressCity
    {
        public int AddressCityID { get; set; }
        public string AddressCityName { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
