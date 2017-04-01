using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(EmployeeStatusDTOValidator))]
    public class EmployeeStatusDTO
    {
        public int EmployeeStatusID { get; set; }
        public string EmployeeStatusName { get; set; }
    }
    public class EmployeeStatusDTOValidator : AbstractValidator<EmployeeStatusDTO>
    {
        public EmployeeStatusDTOValidator()
        {
            RuleFor(ac => ac.EmployeeStatusName)
                .NotEmpty().WithMessage("The Employee's status cannot be blank.")
                .Length(0, 50).WithMessage("The Employee's status cannot be more than 50 characters.");
        }
    }
}
