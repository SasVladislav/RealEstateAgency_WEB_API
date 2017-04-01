using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(AddressDTOValidator))]
    public class AddressDTO
    {
        public int AddressID { get; set; }
        public int AddressCityID { get; set; }
        public int AddressRegionID { get; set; }
        public int AddressStreetID { get; set; }
        public string HomeNumber { get; set; }
        public int? ApartmentNumber { get; set; }
    }
    public class AddressDTOValidator : AbstractValidator<AddressDTO>
    {
        public AddressDTOValidator()
        {
            RuleFor(ac => ac.AddressCityID)
                .NotEmpty().WithMessage("The City cannot be blank.");
            RuleFor(ac => ac.AddressRegionID)
                .NotEmpty().WithMessage("The Region cannot be blank.");
            RuleFor(ac => ac.AddressStreetID)
                .NotEmpty().WithMessage("The Street cannot be blank.");
            RuleFor(ac => ac.HomeNumber)
                .NotEmpty().WithMessage("The Number of Home cannot be blank.")
                .Length(0,50).WithMessage("The Number of Home cannot be more than 50 characters."); ;
            RuleFor(ac => ac.ApartmentNumber);
        }
    }
}
