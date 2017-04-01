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
    public class RealEstateTypeWallEquelSpecification : Specification<RealEstateTypeWall, RealEstateTypeWallDTO>
    {
        RealEstateTypeWallDTO realEstateTypeWallDto;
        public RealEstateTypeWallEquelSpecification(RealEstateTypeWallDTO realEstateTypeWallDto)
        {
            this.realEstateTypeWallDto = realEstateTypeWallDto;
        }
        public override Expression<Func<RealEstateTypeWall, bool>> ToExpression()
        {
            return ac => ac.RealEstateTypeWallName == realEstateTypeWallDto.RealEstateTypeWallName;
        }
    }
    public class RealEstateTypeWallMessageSpecification : SpecificationMessage
    {
        RealEstateTypeWallDTO TypeWallDto;
    public RealEstateTypeWallMessageSpecification(RealEstateTypeWallDTO typeWallDto = null)
    {
        TypeWallDto = typeWallDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Тип стен {TypeWallDto.RealEstateTypeWallName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, $"Тип стен успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Тип стен {TypeWallDto.RealEstateTypeWallName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Тип стен с названием {TypeWallDto.RealEstateTypeWallName} уже существует", "TypeWall");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого типа стен нет в базе данных", "TypeWall");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Типа стен {TypeWallDto.RealEstateTypeWallName} нет в базе данных", "TypeWall");
    }   
}
}
