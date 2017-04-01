using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Specifications
{
    public class UserEquelSpecification : Specification<User, UserDTO>
    {
        UserDTO userDto;
        public UserEquelSpecification(UserDTO userDto)
        {
            this.userDto = userDto;
        }
        public override Expression<Func<User, bool>> ToExpression()
        {
            return u => userDto.Name == u.Name && userDto.Surname == u.Surname &&
                                       userDto.Patronumic == u.Patronumic;
        }
    }
    public class UserMessageSpecification : SpecificationMessage
    {
        UserDTO UserDto;
    public UserMessageSpecification(UserDTO userDto = null)
    {
        UserDto = userDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Пользователь успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, $"Пользователь успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Пользователь успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Пользователь уже существует", "User");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого пользователя нет в базе данных", "User");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Такого пользователя нет в базе данных", "User");
    } 
}
}
