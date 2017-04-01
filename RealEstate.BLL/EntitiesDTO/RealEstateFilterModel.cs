using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class RealEstateFilterModel
    {
        public int? RealEstateID { get; set; }
        public int? RealEstateStatusID { get; set; }
        public int? RealEstateTypeID { get; set; }
        public double? BeginPrice { get; set; }
        public double? EndPrice { get; set; }
        public int? RealEstateClassID { get; set; }
        public int? RealEstateTypeWallID { get; set; }
        public int? BeginNumberOfRooms { get; set; }
        public int? EndNumberOfRooms { get; set; }
        public int? BeginLevel { get; set; }
        public int? EndLevel { get; set; }
        public double? BeginGrossArea { get; set; }
        public double? EndGrossArea { get; set; }
        public string NearSubway { get; set; }
        public bool? Elevator { get; set; }
        public string Image { get; set; }
        public int? AddressID { get; set; }   
    }
}
