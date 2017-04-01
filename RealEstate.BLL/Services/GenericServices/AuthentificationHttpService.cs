using AutoMapper;
using Microsoft.AspNet.Identity;
using Ninject;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Infrastuctures;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Interfaces.GenericInterfaces;
using RealEstateAgency.BLL.Specifications;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.BLL.Services.GenericServices
{
    public class AuthentificationHttpService:IAuthentificationService<ClaimsIdentity>
    {
        IKernel kernel;
        IUnitOfWorkIdentity identity;
        IRepository<User, string> UserRepository;
        IRepository<Employee, string> EmployeeRepository;
        public AuthentificationHttpService(IKernel kernel)
        {
            this.kernel = kernel;
            this.identity = kernel.Get<IUnitOfWorkIdentity>();
            this.UserRepository = kernel.Get<IRepository<User, string>>();
            this.EmployeeRepository = kernel.Get<IRepository<Employee, string>>();
        }
        public async Task<ClaimsIdentity> AuthenticateAsync(PersonAbstractDTO PersonDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await identity.AppUserManager.FindAsync(PersonDto.Email, PersonDto.Password);
            if (user != null)
            {
                claim = await identity.AppUserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }
        
        public async Task SetInitialDataAsync(PersonAbstractDTO PersonDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await identity.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole { Name = roleName };
                    await identity.RoleManager.CreateAsync(role);
                }
            }
            if (PersonDto is UserDTO)
            {
                await kernel.Get<IUserService>().CreateUserAsync((UserDTO)PersonDto,
                    new UserMessageSpecification().ToSuccessCreateMessage(),
                    new UserMessageSpecification().ToFailCreateMessage());
            }
            else
            {
                await kernel.Get<IEmployeeService>().CreateEmployeeAsync((EmployeeDTO)PersonDto,
                    new EmployeeMessageSpecification().ToSuccessCreateMessage(),
                    new EmployeeMessageSpecification().ToFailCreateMessage());
            }

        }
    }
}
