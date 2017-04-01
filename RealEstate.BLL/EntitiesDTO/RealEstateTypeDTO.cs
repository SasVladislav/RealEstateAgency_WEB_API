using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(RealEstateTypeDTOValidator))]
    public class RealEstateTypeDTO
    {
        public int RealEstateTypeID { get; set; }
        public string RealEstateTypeName { get; set; }
    }
    public class RealEstateTypeDTOValidator : AbstractValidator<RealEstateTypeDTO>
    {
        public RealEstateTypeDTOValidator()
        {
            RuleFor(ac => ac.RealEstateTypeName)
                .NotEmpty().WithMessage("The Type of RealEstate cannot be blank.")
                .Length(0, 50).WithMessage("The Type of RealEstate cannot be more than 50 characters.");
        }
    }
}
