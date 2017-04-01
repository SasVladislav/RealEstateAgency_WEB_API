using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class RealEstateTypeFilterModel
    {
        public int? RealEstateTypeID { get; set; }
        public string RealEstateTypeName { get; set; }
    }
}
