using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class RealEstateStatus
    {
        public int RealEstateStatusID { get; set; }
        public string RealEstateStatusName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
