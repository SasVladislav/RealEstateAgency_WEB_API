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
    public class ContractEquelSpecification : Specification<Contract, ContractDTO>
    {
        ContractDTO contractDto;
        public ContractEquelSpecification(ContractDTO contractDto)
        {
            this.contractDto = contractDto;
        }
        public override Expression<Func<Contract, bool>> ToExpression()
        {
            return a => contractDto.ContractID == a.ContractID && contractDto.ContractTypeID == a.ContractTypeID &&
                                       contractDto.EmployeeID == a.EmployeeID && contractDto.RealEstateID == a.RealEstateID &&
                                       contractDto.RecordDate == a.RecordDate && contractDto.SellerID == a.SellerID;
        }
    }
    public class ContractMessageSpecification : SpecificationMessage
    {
        ContractDTO ContractDto;
    public ContractMessageSpecification(ContractDTO contractDto = null)
    {
            ContractDto = contractDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Договор успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, $"Договор успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Договор успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Договор уже существует", "Contract");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого договора нет в базе данных", "Contract");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Такого договора нет в базе данных", "Contract");
    }

    
}
}
