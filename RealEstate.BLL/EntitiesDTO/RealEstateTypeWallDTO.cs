using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(RealEstateTypeWallDTOValidator))]
    public class RealEstateTypeWallDTO
    {
        public int RealEstateTypeWallID { get; set; }
        public string RealEstateTypeWallName { get; set; }
    }
    public class RealEstateTypeWallDTOValidator : AbstractValidator<RealEstateTypeWallDTO>
    {
        public RealEstateTypeWallDTOValidator()
        {
            RuleFor(ac => ac.RealEstateTypeWallName)
                .NotEmpty().WithMessage("The Type Wall of RealEstate cannot be blank.")
                .Length(0, 50).WithMessage("The Type Wall of RealEstate cannot be more than 50 characters.");
        }
    }
}
