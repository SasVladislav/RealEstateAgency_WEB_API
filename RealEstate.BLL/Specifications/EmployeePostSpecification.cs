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
    public class EmployeePostEquelSpecification : Specification<EmployeePost, EmployeePostDTO>
    {
        EmployeePostDTO employeePostDto;
        public EmployeePostEquelSpecification(EmployeePostDTO employeePostDto)
        {
            this.employeePostDto = employeePostDto;
        }
        public override Expression<Func<EmployeePost, bool>> ToExpression()
        {
            return ac => ac.EmployeePostName == employeePostDto.EmployeePostName;
        }
    }
    public class EmployeePostMessageSpecification : SpecificationMessage
    {
        EmployeePostDTO PostDto;
    public EmployeePostMessageSpecification(EmployeePostDTO postDto = null)
    {
            PostDto = postDto;
    }

    public override OperationDetails ToSuccessCreateMessage()
    {
        return new OperationDetails(true, $"Должность {PostDto.EmployeePostName} успешно добавлена", "");
    }

    public override OperationDetails ToSuccessDeleteMessage()
    {
        return new OperationDetails(true, "Должность успешно удалена", "");
    }

    public override OperationDetails ToSuccessUpdateMessage()
    {
        return new OperationDetails(true, $"Должность {PostDto.EmployeePostName} успешно изменена", "");
    }

    public override OperationDetails ToFailCreateMessage()
    {
        return new OperationDetails(false, $"Должность с названием {PostDto.EmployeePostName} уже существует", "Post");
    }

    public override OperationDetails ToFailDeleteMessage()
    {
        return new OperationDetails(false, "Такой должности нет в базе данных", "Post");
    }

    public override OperationDetails ToFailUpdateMessage()
    {
        return new OperationDetails(false, $"Должности {PostDto.EmployeePostName} нет в базе данных", "Post");
    }

    
}
}
