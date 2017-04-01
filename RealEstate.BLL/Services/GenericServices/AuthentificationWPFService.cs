using Microsoft.AspNet.Identity;
using Ninject;
using RealEstateAgency.BLL.EntitiesDTO;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Interfaces.GenericInterfaces;
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
    public class AuthentificationWPFService : IAuthentificationService<string>
    {
        IKernel kernel;
        IUnitOfWorkIdentity identity;
        public AuthentificationWPFService(IKernel kernel)
        {
            this.kernel = kernel;
            this.identity = kernel.Get<IUnitOfWorkIdentity>();
        }
        public async Task<string> AuthenticateAsync(PersonAbstractDTO PersonDto)
        {
            string Auth = "";
            ApplicationUser user = await identity.AppUserManager.FindAsync(PersonDto.Email, PersonDto.Password);
            if (user != null)
            {
                Auth = user.Id;
            }
            return Auth;
        }

        public async Task SetInitialDataAsync(PersonAbstractDTO PersonDto, List<string> roles)
        {
           await new AuthentificationHttpService(kernel).SetInitialDataAsync(PersonDto,roles);
        }
    }
}
