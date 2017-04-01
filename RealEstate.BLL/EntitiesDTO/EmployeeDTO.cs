using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(EmployeeDTOValidator))]
    public class EmployeeDTO:PersonAbstractDTO
    {
        public int EmployeePostID { get; set; }
        public int EmployeeStatusID { get; set; }
        public bool StateOnline { get; set; }
    }
    public class EmployeeDTOValidator : PersonsAbstractDTOValidator<EmployeeDTO>
    {
        public EmployeeDTOValidator()
        {
            RuleFor(ac => ac.EmployeePostID)
               .NotEmpty().WithMessage("The Employee's position cannot be blank.");
            RuleFor(ac => ac.EmployeeStatusID)
               .NotEmpty().WithMessage("The Employee's status cannot be blank.");
            //RuleFor(ac => ac.StateOnline)
            //   .NotEmpty().WithMessage("The State online cannot be blank.");
        }
    }
}
