using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class EmployeeFilterModel : PersonAbstractFilterModel
    {
        public int? EmployeePostID { get; set; }
        public int? EmployeeStatusID { get; set; }
        public bool? StateOnline { get; set; }
    }
}
