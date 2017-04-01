using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(AddressStreetDTOValidator))]
    public class AddressStreetDTO
    {
        public int AddressStreetID { get; set; }
        public string AddressStreetName { get; set; }
    }
    public class AddressStreetDTOValidator : AbstractValidator<AddressStreetDTO>
    {
        public AddressStreetDTOValidator()
        {
            RuleFor(ac => ac.AddressStreetName)
                .NotEmpty().WithMessage("The Street cannot be blank.")
                .Length(0, 50).WithMessage("The Street cannot be more than 50 characters.");
        }
    }
}
