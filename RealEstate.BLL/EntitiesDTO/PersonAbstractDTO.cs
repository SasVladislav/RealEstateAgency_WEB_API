using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    public abstract class PersonAbstractDTO
    {
        public string PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronumic { get; set; }
        public int PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public int AddressID { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public abstract class PersonsAbstractDTOValidator<T> : AbstractValidator<T> where T:PersonAbstractDTO
    {
        public PersonsAbstractDTOValidator()
        {
            RuleFor(ac => ac.Name)
                .NotEmpty().WithMessage("The Name cannot be blank.")
                .Length(0, 50).WithMessage("The Name cannot be more than 50 characters.");
            RuleFor(ac => ac.Surname)
                .NotNull().WithMessage("The Surname cannot be blank.")
                .Length(0, 50).WithMessage("The Surname cannot be more than 50 characters.");
            RuleFor(ac => ac.Patronumic)
                .NotEmpty().WithMessage("The Patronumic cannot be blank.")
                .Length(0, 50).WithMessage("The Patronumic cannot be more than 50 characters.");
            RuleFor(ac => ac.PhoneNumber)
                .NotEmpty().WithMessage("The PhoneNumber cannot be blank.");
            RuleFor(ac => ac.AddressID)
                .NotEmpty().WithMessage("The Address cannot be blank.");
            RuleFor(ac => ac.PassportNumber)
                .NotEmpty().WithMessage("The Passpost cannot be blank.");
            //RuleFor(ac => ac.Email)
            //    .NotEmpty().WithMessage("The Email cannot be blank.")
            //    .Length(0, 50).WithMessage("The Email cannot be more than 50 characters.");
            //RuleFor(ac => ac.Password)
            //    .NotEmpty().WithMessage("The Password cannot be blank.")
            //    .Length(0, 50).WithMessage("The Password cannot be more than 50 characters.");
        }
    }
}
