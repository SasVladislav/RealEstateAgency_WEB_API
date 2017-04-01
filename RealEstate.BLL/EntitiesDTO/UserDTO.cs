using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Attributes;
using FluentValidation;

namespace RealEstateAgency.BLL.EntitiesDTO
{
    [Validator(typeof(UserDTOValidator))]
    public class UserDTO:PersonAbstractDTO
    {        
    }
    public class UserDTOValidator : PersonsAbstractDTOValidator<UserDTO>
    {
        public UserDTOValidator(){}
    }
}
