using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class RealEstateType
    {
        public int RealEstateTypeID { get; set; }
        public string RealEstateTypeName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
