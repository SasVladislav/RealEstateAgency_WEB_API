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
    public class EmployeeStatusEquelSpecification : Specification<EmployeeStatus, EmployeeStatusDTO>
    {
        EmployeeStatusDTO employeeStatusDto;
        public EmployeeStatusEquelSpecification(EmployeeStatusDTO employeeStatusDto)
        {
            this.employeeStatusDto = employeeStatusDto;
        }
        public override Expression<Func<EmployeeStatus, bool>> ToExpression()
        {
            return ac => ac.EmployeeStatusName == employeeStatusDto.EmployeeStatusName;
        }
    }
    public class EmployeeStatusMessageSpecification : SpecificationMessage
    {
        EmployeeStatusDTO StatusDto;
        public EmployeeStatusMessageSpecification(EmployeeStatusDTO statusDto = null)
        {
            StatusDto = statusDto;
        }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Статус сотрудника {StatusDto.EmployeeStatusName} успешно добавлен", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Статус сотрудника успешно удален", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Статус сотрудника {StatusDto.EmployeeStatusName} успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Статус сотрудника с названием {StatusDto.EmployeeStatusName} уже существует", "Status");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такого статуса сотрудника нет в базе данных", "Status");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Статуса сотрудника {StatusDto.EmployeeStatusName} нет в базе данных", "Status");
    }

}
}
