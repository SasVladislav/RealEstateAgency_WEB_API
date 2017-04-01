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
    public class AddressRegionEquelSpecification: Specification<AddressRegion, AddressRegionDTO>
    {
        AddressRegionDTO addressRegionDto;
        public AddressRegionEquelSpecification(AddressRegionDTO addressRegionDto)
        {
            this.addressRegionDto = addressRegionDto;
        }
        public override Expression<Func<AddressRegion, bool>> ToExpression()
        {
            return ar => ar.AddressRegionName == addressRegionDto.AddressRegionName;
        }
    }

    public class AddressRegionMessageSpecification : SpecificationMessage
    {
        AddressRegionDTO RegionDto;
    public AddressRegionMessageSpecification(AddressRegionDTO regionDto = null)
    {
        RegionDto = regionDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Регион {RegionDto.AddressRegionName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Регион успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Регион {RegionDto.AddressRegionName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Регион с названием {RegionDto.AddressRegionName} уже существует", "Region");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого региона нет в базе данных", "Region");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Региона {RegionDto.AddressRegionName} нет в базе данных", "Region");
    }
}
}
