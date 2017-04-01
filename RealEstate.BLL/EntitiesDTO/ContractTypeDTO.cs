using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(ContractTypeDTOValidator))]
    public class ContractTypeDTO
    {
        public int ContractTypeID { get; set; }
        public string ContractTypeName { get; set; }
    }
    public class ContractTypeDTOValidator : AbstractValidator<ContractTypeDTO>
    {
        public ContractTypeDTOValidator()
        {
            RuleFor(ac => ac.ContractTypeName)
                .NotEmpty().WithMessage("Type of Contract cannot be blank.")
                .Length(0, 50).WithMessage("Type of Contract cannot be more than 50 characters.");
        }
    }
}
