using RealEstateAgency.BLL.EntitiesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Interfaces.GenericInterfaces
{
    public interface IAuthentificationService<T>
    {
        Task<T> AuthenticateAsync(PersonAbstractDTO PersonDto);
        Task SetInitialDataAsync(PersonAbstractDTO PersonDto, List<string> roles);
    }
}
