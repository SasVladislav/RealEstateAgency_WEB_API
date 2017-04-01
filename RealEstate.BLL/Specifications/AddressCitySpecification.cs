using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RealEstateAgency.BLL.Infrastuctures;

namespace RealEstateAgency.BLL.Specifications
{
    public class AddressCityEquelSpecification : Specification<AddressCity,AddressCityDTO>
    {
        AddressCityDTO addressCityDto;
        public AddressCityEquelSpecification(AddressCityDTO addressCityDto)
        {
            this.addressCityDto = addressCityDto;
        }
        public override Expression<Func<AddressCity, bool>> ToExpression()
        {
            return ac => ac.AddressCityName == addressCityDto.AddressCityName;
        }
    }
    public class AddressCityMessageSpecification : SpecificationMessage
    {
        AddressCityDTO CityDto;
        public AddressCityMessageSpecification(AddressCityDTO cityDto=null)
        {
            CityDto = cityDto;
        }

        public override OperationDetails ToFailCreateMessage()
        {
            return new OperationDetails(false, $"Город с названием {CityDto.AddressCityName} уже существует", "City");
        }

        public override OperationDetails ToFailDeleteMessage()
        {
            return new OperationDetails(false, "Такого города нет в базе данных", "City");
        }

        public override OperationDetails ToFailUpdateMessage()
        {
            return new OperationDetails(false, $"Города {CityDto.AddressCityName} нет в базе данных", "City");
        }

        public override OperationDetails ToSuccessCreateMessage()
        {
            return new OperationDetails(true, $"Город {CityDto.AddressCityName} успешно добавлен", "");
        }

        public override OperationDetails ToSuccessDeleteMessage()
        {
            return new OperationDetails(true, "Город успешно удален", "");
        }

        public override OperationDetails ToSuccessUpdateMessage()
        {
            return new OperationDetails(true, $"Город {CityDto.AddressCityName} успешно изменен", "");
        }
    }
}
