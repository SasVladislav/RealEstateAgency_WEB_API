using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(EmployeeDismissDTOValidator))]
    public class EmployeeDismissDTO
    {
        public int EmployeeDismissId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? DismissDate { get; set; }
        
    }
    public class EmployeeDismissDTOValidator : AbstractValidator<EmployeeDismissDTO>
    {
        public EmployeeDismissDTOValidator()
        {
            RuleFor(ac => ac.EmployeeId)
                .NotEmpty().WithMessage("The Employee cannot be blank.");
            RuleFor(ac => ac.EmploymentDate)
                .Equal(DateTime.Today).WithMessage("You cannot enter a Employment date in the future.");
            RuleFor(ac => ac.DismissDate)
                .Equal(DateTime.Today).WithMessage("You cannot enter a Dismiss date in the future.");
        }
    }
}
