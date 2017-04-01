using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities
{
    public class RealEstate
    {
        public int RealEstateID { get; set; }
        public int RealEstateStatusID { get; set; }
        public int RealEstateTypeID { get; set; }
        public double Price { get; set; }
        public int RealEstateClassID { get; set; }
        public int RealEstateTypeWallID { get; set; }
        public int NumberOfRooms { get; set; }
        public int Level { get; set; }
        public double GrossArea { get; set; }
        public string NearSubway { get; set; }
        public bool Elevator { get; set; }
        public string Image { get; set; }
        public int AddressID { get; set; }
        public virtual RealEstateStatus RealEstateStatus { get; set; }
        public virtual RealEstateType RealEstateType { get; set; }
        public virtual RealEstateClass RealEstateClass { get; set; }
        public virtual RealEstateTypeWall RealEstateTypeWall { get; set; }
        public virtual Address Address { get; set; }
    }
}
