using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(AddressRegionDTOValidator))]
    public class AddressRegionDTO
    {
        public int AddressRegionID { get; set; }
        public string AddressRegionName { get; set; }
    }
    public class AddressRegionDTOValidator : AbstractValidator<AddressRegionDTO>
    {
        public AddressRegionDTOValidator()
        {
            RuleFor(ac => ac.AddressRegionName)
                .NotEmpty().WithMessage("The Region cannot be blank.")
                .Length(0, 50).WithMessage("The Region cannot be more than 50 characters.");
        }
    }
}
