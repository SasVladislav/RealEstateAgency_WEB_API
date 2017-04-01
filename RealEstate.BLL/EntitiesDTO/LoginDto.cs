using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(LoginDTOValidator))]
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class LoginDTOValidator : AbstractValidator<LoginDto>
    {
        public LoginDTOValidator()
        {
            RuleFor(ac => ac.Email)
                .NotEmpty().WithMessage("The Email cannot be blank.")                
                .Length(0, 50).WithMessage("The Email cannot be more than 50 characters.");
            RuleFor(ac => ac.Password)
                .NotEmpty().WithMessage("The Password cannot be blank.")
                .Length(0, 50).WithMessage("The Password cannot be more than 50 characters.");
        }
    }
}
