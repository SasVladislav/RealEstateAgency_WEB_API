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
    public class AddressStreetEquelSpecification : Specification<AddressStreet, AddressStreetDTO>
    {
        AddressStreetDTO addressStreetDto;
        public AddressStreetEquelSpecification(AddressStreetDTO addressStreetDto)
        {
            this.addressStreetDto = addressStreetDto;
        }
        public override Expression<Func<AddressStreet, bool>> ToExpression()
        {
            return ac => ac.AddressStreetName == addressStreetDto.AddressStreetName;
        }
    }
    public class AddressStreetMessageSpecification : SpecificationMessage
    {
        AddressStreetDTO StreetDto;
    public AddressStreetMessageSpecification(AddressStreetDTO streetDto = null)
    {
            StreetDto = streetDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Улица {StreetDto.AddressStreetName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Улица  успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Улица {StreetDto.AddressStreetName} успешно изменена", "");
    }
    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Улица с названием {StreetDto.AddressStreetName} уже существует", "Street");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такой улицы нет в базе данных", "Street");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Улицы {StreetDto.AddressStreetName} нет в базе данных", "Street");
    }

    
}
}
