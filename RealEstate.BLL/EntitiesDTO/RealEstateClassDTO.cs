using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(RealEstateClassDTOValidator))]
    public class RealEstateClassDTO
    { 
    public int RealEstateClassID { get; set; }
    public string RealEstateClassName { get; set; }
    }
    public class RealEstateClassDTOValidator : AbstractValidator<RealEstateClassDTO>
    {
        public RealEstateClassDTOValidator()
        {
            RuleFor(ac => ac.RealEstateClassName)
                .NotEmpty().WithMessage("The Class of RealEstate cannot be blank.")
                .Length(0, 50).WithMessage("The Class of RealEstate cannot be more than 50 characters.");
        }
    }
}
