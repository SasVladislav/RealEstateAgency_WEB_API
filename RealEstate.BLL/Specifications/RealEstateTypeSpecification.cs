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
    public class RealEstateTypeEquelSpecification : Specification<RealEstateType, RealEstateTypeDTO>
    {
        RealEstateTypeDTO realEstateTypeDto;
        public RealEstateTypeEquelSpecification(RealEstateTypeDTO realEstateTypeDto)
        {
            this.realEstateTypeDto = realEstateTypeDto;
        }
        public override Expression<Func<RealEstateType, bool>> ToExpression()
        {
            return ac => ac.RealEstateTypeName == realEstateTypeDto.RealEstateTypeName;
        }
    }
    public class RealEstateTypeMessageSpecification : SpecificationMessage
    {
        RealEstateTypeDTO TypeDto;
    public RealEstateTypeMessageSpecification(RealEstateTypeDTO typeDto = null)
    {
            TypeDto = typeDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Тип недвижимости {TypeDto.RealEstateTypeName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Тип недвижимости успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Тип недвижимости {TypeDto.RealEstateTypeName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Тип недвижимости с названием {TypeDto.RealEstateTypeName} уже существует", "Type");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого типа недвижимости нет в базе данных", "Type");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"тип недвижимости {TypeDto.RealEstateTypeName} нет в базе данных", "Type");
    }  
}
}
