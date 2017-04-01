using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class RealEstateClassFilterModel
    { 
    public int? RealEstateClassID { get; set; }
    public string RealEstateClassName { get; set; }
    }
}
