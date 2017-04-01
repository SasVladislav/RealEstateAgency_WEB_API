using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public class EmployeeDismissFilterModel
    {
        public int? EmployeeDismissId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissDate { get; set; }
        
    }
}
