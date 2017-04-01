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
    public class EmployeeEquelSpecification : Specification<Employee, EmployeeDTO>
    {
        EmployeeDTO employeeDto;
        public EmployeeEquelSpecification(EmployeeDTO employeeDto)
        {
            this.employeeDto = employeeDto;
        }
        public override Expression<Func<Employee, bool>> ToExpression()
        {
            return e => employeeDto.Name == e.Name && employeeDto.Surname == e.Surname &&
                                       employeeDto.Patronumic == e.Patronumic;
        }
    }
    public class EmployeeMessageSpecification : SpecificationMessage
    {
        EmployeeDTO EmployeeDto;
    public EmployeeMessageSpecification(EmployeeDTO employeeDto = null)
    {
        EmployeeDto = employeeDto;
    }
    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, "Сотрудник успешно добавлен", "");
    }

    public OperationDetails ToSuccessCreateExistMessage()
    {
        return new OperationDetails(true, "Сотрудник успешно работает", "");
    }
    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Сотрудник успешно уволен", "");
    }
    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, "Сотрудник успешно изменен", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, "Сотрудник уже существует", "Employee");
    }

    public OperationDetails ToFailCreateExistMessage()
    {
        return new OperationDetails(false, "Сотрудник уже работает", "EmployeeDismiss");
    }
    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Сотрудник уже уволен", "Desmiss");
    }
    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, "Такого сотрудника нет в базе данных", "Employee");
    }
    
    }
}
