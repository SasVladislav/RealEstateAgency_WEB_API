using RealEstateAgency.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.DAL.Entities;
using System.Linq.Expressions;
using RealEstateAgency.BLL.Infrastuctures;

namespace RealEstateAgency.BLL.Specifications
{
    public class RealEstateStatusEquelSpecification : Specification<RealEstateStatus, RealEstateStatusDTO>
    {
        RealEstateStatusDTO realEstateStatusDto;

        public RealEstateStatusEquelSpecification(RealEstateStatusDTO realEstateStatusDto)
        {
            this.realEstateStatusDto = realEstateStatusDto;
        }

        public override Expression<Func<RealEstateStatus, bool>> ToExpression()
        {
            return ac => ac.RealEstateStatusName == realEstateStatusDto.RealEstateStatusName;
        }
    }
    public class RealEstateStatusMessageSpecification : SpecificationMessage
    {
        RealEstateStatusDTO StatusDto;
    public RealEstateStatusMessageSpecification(RealEstateStatusDTO statusDto = null)
    {
            StatusDto = statusDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Статус недвижимости {StatusDto.RealEstateStatusName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Статус недвижимости успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Статус недвижимости {StatusDto.RealEstateStatusName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Статус недвижимости с названием {StatusDto.RealEstateStatusName} уже существует", "Status");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого статуса недвижимости нет в базе данных", "Status");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Статуса недвижимости {StatusDto.RealEstateStatusName} нет в базе данных", "Status");
    }

    
}
}
