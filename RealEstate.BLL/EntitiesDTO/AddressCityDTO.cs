using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(AddressCityDTOValidator))]
    public class AddressCityDTO
    {
        public int AddressCityID { get; set; }
        public string AddressCityName { get; set; }

    }
    public class AddressCityDTOValidator : AbstractValidator<AddressCityDTO>
    {
        public AddressCityDTOValidator()
        {
            RuleFor(ac => ac.AddressCityName)
                .NotEmpty().WithMessage("The City cannot be blank.")
                .Length(0, 50).WithMessage("The City cannot be more than 50 characters.");
        }
    }
}
