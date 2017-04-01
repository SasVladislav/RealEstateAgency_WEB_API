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
    public class RealEstateEquelSpecification : Specification<RealEstate, RealEstateDTO>
    {
        RealEstateDTO realEstateDto;
        public RealEstateEquelSpecification(RealEstateDTO realEstateDto)
        {
            this.realEstateDto = realEstateDto;
        }
        public override Expression<Func<RealEstate, bool>> ToExpression()
        {
            return a => (realEstateDto.RealEstateID == a.RealEstateID && realEstateDto.AddressID == a.AddressID &&
                                       realEstateDto.Elevator == a.Elevator && realEstateDto.GrossArea == a.GrossArea &&
                                       realEstateDto.Image == a.Image && realEstateDto.NearSubway == a.NearSubway &&
                                       realEstateDto.NumberOfRooms == a.NumberOfRooms && realEstateDto.Price == a.Price &&
                                       realEstateDto.RealEstateClassID == a.RealEstateClassID && realEstateDto.RealEstateStatusID == a.RealEstateStatusID &&
                                       realEstateDto.RealEstateTypeID == a.RealEstateTypeID && realEstateDto.RealEstateTypeWallID == a.RealEstateTypeWallID
                                       ) || realEstateDto.RealEstateID == a.RealEstateID;
        }
    }
    public class RealEstateMessageSpecification : SpecificationMessage
    {
        RealEstateDTO RealEstateDto;
    public RealEstateMessageSpecification(RealEstateDTO realEstateDto = null)
    {
            RealEstateDto = realEstateDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, "Недвижимость успешно добавлена", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(false, "Такой недвижимости нет в базе данных", "RealEstate");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, "Недвижимость успешно изменена", "");
    }
    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, "Недвижимость уже существует", "RealEstate");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(true, "Недвижимость успешно удалена", "");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, "Такой недвижимости нет в базе данных", "RealEstate");
    }

}
}
