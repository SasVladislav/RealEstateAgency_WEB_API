using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class RealEstateClass
    {
        public int RealEstateClassID { get; set; }
        public string RealEstateClassName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }

    }
}
