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
    public class ContractTypeEquelSpecification : Specification<ContractType, ContractTypeDTO>
    {
        ContractTypeDTO contractTypeDto;
        public ContractTypeEquelSpecification(ContractTypeDTO contractTypeDto)
        {
            this.contractTypeDto = contractTypeDto;
        }
        public override Expression<Func<ContractType, bool>> ToExpression()
        {
            return ac => ac.ContractTypeName == contractTypeDto.ContractTypeName;
        }
    }
    public class ContractTypeMessageSpecification : SpecificationMessage
    {
        ContractTypeDTO TypeDto;
    public ContractTypeMessageSpecification(ContractTypeDTO typeDto = null)
    {
        TypeDto = typeDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Тип контракта {TypeDto.ContractTypeName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Тип контракта успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Тип контракта {TypeDto.ContractTypeName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Тип контракта с названием {TypeDto.ContractTypeName} уже существует", "ContractTypes");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого типа контракта нет в базе данных", "ContractTypes");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Типа контракта {TypeDto.ContractTypeName} нет в базе данных", "ContractTypes");
    }

    
}
}
