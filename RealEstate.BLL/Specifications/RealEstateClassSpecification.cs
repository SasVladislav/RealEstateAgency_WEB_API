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
    public class RealEstateClassEquelSpecification: Specification<RealEstateClass, RealEstateClassDTO>
    {
        RealEstateClassDTO realEstateClassDto;
        public RealEstateClassEquelSpecification(RealEstateClassDTO realEstateClassDto)
        {
            this.realEstateClassDto = realEstateClassDto;
        }
        public override Expression<Func<RealEstateClass, bool>> ToExpression()
        {
            return ac => ac.RealEstateClassName == realEstateClassDto.RealEstateClassName;
        }
    }
    public class RealEstateClassMessageSpecification : SpecificationMessage
    {
        RealEstateClassDTO ClassDto;
    public RealEstateClassMessageSpecification(RealEstateClassDTO classDto = null)
    {
        ClassDto = classDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Класс недвижимости {ClassDto.RealEstateClassName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Класс недвижимости успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Класс недвижимости {ClassDto.RealEstateClassName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Класс недвижимости с названием {ClassDto.RealEstateClassName} уже существует", "Class");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого класса недвижимости нет в базе данных", "Class");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Класс недвижимости {ClassDto.RealEstateClassName} нет в базе данных", "Class");
    }
}
}
