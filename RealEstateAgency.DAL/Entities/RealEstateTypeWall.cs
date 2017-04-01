using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class RealEstateTypeWall
    {
        public int RealEstateTypeWallID { get; set; }
        public string RealEstateTypeWallName { get; set; }
        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
