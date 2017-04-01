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
    public class EmployeeDismissEquelSpecification : Specification<EmployeeDismiss, EmployeeDismissDTO>
    {
        EmployeeDismissDTO employeeDismissDto;
        public EmployeeDismissEquelSpecification(EmployeeDismissDTO employeeDismissDto)
        {
            this.employeeDismissDto = employeeDismissDto;
        }
        public override Expression<Func<EmployeeDismiss, bool>> ToExpression()
        {
            return a => employeeDismissDto.EmploymentDate == a.EmploymentDate &&
                employeeDismissDto.DismissDate == a.DismissDate && employeeDismissDto.EmployeeId == a.EmployeeId;
        }
    }
    public class EmployeeDismissMessageSpecification : SpecificationMessage
    {
        EmployeeDismissDTO DismissDto;
    public EmployeeDismissMessageSpecification(EmployeeDismissDTO dismissDto = null)
    {
            DismissDto = dismissDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
            return new OperationDetails(true, $"Дата приема на работу или дата увольнения пользователя успешно добавлена", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Запись приема на работу или увольнения успешно удалена", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, "Запись приема на работу или увольнения успешно измененена", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
            return new OperationDetails(false, $"Дата приема на работу или дата увольнения пользователя уже существует", "EmployeeDismiss");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такой записи приема на работу или увольнения нет в базе данных", "EmployeeDismiss");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, "Такой запись приема на работу или увольнения нет в базе данных", "EmployeeDismiss");
    }

}
}
