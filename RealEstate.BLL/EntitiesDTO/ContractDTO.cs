using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(ContractDTOValidator))]
    public class ContractDTO
    {
        public int ContractID { get; set; }
        public int RealEstateID { get; set; }
        public string BuyerID { get; set; }
        public string SellerID { get; set; }
        public string EmployeeID { get; set; }
        public int ContractTypeID { get; set; }
        public string RecordDate { get; set; }
    }
    public class ContractDTOValidator : AbstractValidator<ContractDTO>
    {
        public ContractDTOValidator()
        {
            RuleFor(ac => ac.RealEstateID)
                .NotEmpty().WithMessage("The RealEstate cannot be blank.");
            RuleFor(ac => ac.SellerID)
                .NotEmpty().WithMessage("The User cannot be blank.");
            RuleFor(ac => ac.EmployeeID)
                .NotEmpty().WithMessage("The Employee cannot be blank.");
            RuleFor(ac => ac.ContractTypeID)
                .NotEmpty().WithMessage("The Type of Contract cannot be blank.");
            RuleFor(ac => ac.RecordDate)
                .NotEmpty().WithMessage("You cannot enter a Record date in the future.");
        }
    }
}
