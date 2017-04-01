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
   public class AddressEquelSpecification:Specification<Address, AddressDTO>
    {
        AddressDTO addressDto;
        public AddressEquelSpecification(AddressDTO addressDto)
        {
            this.addressDto = addressDto;
        }
        public override Expression<Func<Address, bool>> ToExpression()
        {
            return a => (addressDto.AddressCityID == a.AddressCityID &&
                                       addressDto.AddressRegionID == a.AddressRegionID && addressDto.AddressStreetID == a.AddressStreetID &&
                                       addressDto.ApartmentNumber == a.ApartmentNumber && addressDto.HomeNumber == a.HomeNumber) || addressDto.AddressID == a.AddressID;
        }
    }
    public class AddressMessageSpecification : SpecificationMessage
    {
        AddressDTO AddressDto;
        public AddressMessageSpecification(AddressDTO addressDto = null)
        {
            AddressDto = addressDto;
        }
        public override OperationDetails ToSuccessCreateMessage()
        {
            return new OperationDetails(true, $"Адрес успешно добавлен", "");
        }

        public override OperationDetails ToSuccessDeleteMessage()
        {
            return new OperationDetails(true, "Адрес успешно удален", "");
        }

        public override OperationDetails ToSuccessUpdateMessage()
        {
            return new OperationDetails(true, $"Адрес успешно изменен", "");
        }

        public override OperationDetails ToFailCreateMessage()
        {
            return new OperationDetails(false, $"Адрес уже существует", "Address");
        }

        public override OperationDetails ToFailDeleteMessage()
        {
            return new OperationDetails(false, "Такого адреса нет в базе данных", "Address");
        }

        public override OperationDetails ToFailUpdateMessage()
        {
            return new OperationDetails(false, $"Такого адреса нет в базе данных", "Address");
        }

        
    }
}
