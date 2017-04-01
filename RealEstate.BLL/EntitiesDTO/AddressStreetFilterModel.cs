using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class AddressStreetFilterModel
    {
        public int? AddressStreetID { get; set; }
        public string AddressStreetName { get; set; }
    }
}
