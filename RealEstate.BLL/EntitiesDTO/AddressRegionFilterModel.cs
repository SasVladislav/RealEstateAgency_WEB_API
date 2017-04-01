using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class AddressRegionFilterModel
    {
        public int? AddressRegionID { get; set; }
        public string AddressRegionName { get; set; }
    }
}
