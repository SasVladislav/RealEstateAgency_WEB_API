using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(RealEstateDTOValidator))]
    public class RealEstateDTO
    {
        public int RealEstateID { get; set; }
        public int RealEstateStatusID { get; set; }
        public int RealEstateTypeID { get; set; }
        public double Price { get; set; }
        public int RealEstateClassID { get; set; }
        public int RealEstateTypeWallID { get; set; }
        public int Level { get; set; }
        public int NumberOfRooms { get; set; }
        public double GrossArea { get; set; }
        public string NearSubway { get; set; }
        public bool Elevator { get; set; }
        public string Image { get; set; }
        public int AddressID { get; set; }
    }
    public class RealEstateDTOValidator : AbstractValidator<RealEstateDTO>
    {
        public RealEstateDTOValidator()
        {
            RuleFor(ac => ac.RealEstateStatusID)
                .NotEmpty().WithMessage("The Status of RealEstate cannot be blank.");
            RuleFor(ac => ac.RealEstateTypeID)
                .NotEmpty().WithMessage("The Type of RealEstate cannot be blank.");
            RuleFor(ac => ac.Price)
                .NotEmpty().WithMessage("The Price cannot be blank.");
            RuleFor(ac => ac.RealEstateClassID)
                .NotEmpty().WithMessage("The Class of RealEstate cannot be blank.");
            RuleFor(ac => ac.RealEstateTypeWallID)
                .NotEmpty().WithMessage("The Type Wall of RealEstate cannot be blank.");
            RuleFor(ac => ac.Level)
                .NotEmpty().WithMessage("The Level cannot be blank.");
            RuleFor(ac => ac.NumberOfRooms)
                .NotEmpty().WithMessage("The Number of Rooms cannot be blank.");
            RuleFor(ac => ac.GrossArea)
                .NotEmpty().WithMessage("The Gross Area cannot be blank.");
            RuleFor(ac => ac.NearSubway)
                .NotEmpty().WithMessage("The Near Subway cannot be blank.")
                .Length(0, 50).WithMessage("The Near Subway cannot be more than 50 characters.");
            //RuleFor(ac => ac.Image)
            //    .NotEmpty().WithMessage("The Image cannot be blank.");
            RuleFor(ac => ac.AddressID)
                .NotEmpty().WithMessage("The Address cannot be blank.");
        }
    }
}
