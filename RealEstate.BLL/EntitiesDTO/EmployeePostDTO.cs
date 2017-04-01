using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(EmployeePostDTOValidator))]
    public class EmployeePostDTO
    {
        public int EmployeePostID { get; set; }
        public string EmployeePostName { get; set; }
        public double? EmployeePostSalary { get; set; }
    }
    public class EmployeePostDTOValidator : AbstractValidator<EmployeePostDTO>
    {
        public EmployeePostDTOValidator()
        {
            RuleFor(ac => ac.EmployeePostName)
                .NotEmpty().WithMessage("The Employee's position cannot be blank.")
                .Length(0, 50).WithMessage("The Employee's position cannot be more than 50 characters.");
            RuleFor(ac => ac.EmployeePostSalary)
                .NotEmpty().WithMessage("The Employee's salary cannot be blank.");
        }
    }
}
