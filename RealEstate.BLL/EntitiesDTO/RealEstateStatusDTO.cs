using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(RealEstateStatusDTOValidator))]
    public class RealEstateStatusDTO
    {
        public int RealEstateStatusID { get; set; }
        public string RealEstateStatusName { get; set; }
    }
    public class RealEstateStatusDTOValidator : AbstractValidator<RealEstateStatusDTO>
    {
        public RealEstateStatusDTOValidator()
        {
            RuleFor(ac => ac.RealEstateStatusName)
                .NotEmpty().WithMessage("The Status of RealEstate cannot be blank.")
                .Length(0, 50).WithMessage("The Status of RealEstate cannot be more than 50 characters.");
        }
    }
}
