using Ninject.Modules;
using RealEstateAgency.DAL.Interfaces;
using RealEstateAgency.DAL.Repositories;
using RealEstateAgency.DAL.EF;
using RealEstateAgency.BLL.Services;
using RealEstateAgency.BLL.Interfaces;
using RealEstateAgency.BLL.Services.GenericServices;
using RealEstateAgency.BLL.Interfaces.GenericInterfaces;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System.Security.Claims;
using RealEstateAgency.BLL.Service;

namespace RealEstateAgency.BLL.Infrastuctures
{
    public class DependencyInjectionServices :NinjectModule
    {
        public override void Load()
        {
            // generic repository binding
            Bind(typeof(IRepository<,>)).To(typeof(Repository<,>))
                .WithConstructorArgument("dbContext", ctx => ctx.Kernel.Get<IdentityDbContext>());
            Bind(typeof(IServiceT<,,>)).To(typeof(ServiceT<,,>));
            Bind<IUnitOfWorkIdentity>().To<UnitOfWorkIdentity>()
                .WithConstructorArgument("dbContext", ctx => ctx.Kernel.Get<IdentityDbContext>()); 
            // bind dbcontext to your entities extension
            Bind<IdentityDbContext>().To<RealEstateContext>();
             
            Bind<IAddressCityService>().To<AddressCityService>();
            Bind<IAddressRegionService>().To<AddressRegionService>();
            Bind<IAddressService>().To<AddressService>();
            Bind<IAddressStreetService>().To<AddressStreetService>();
            Bind<IContractService>().To<ContractService>();
            Bind<IContractTypeService>().To<ContractTypeService>();
            Bind<IEmployeeDismissService>().To<EmployeeDismissService>();
            Bind<IEmployeePostService>().To<EmployeePostService>();
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IEmployeeStatusService>().To<EmployeeStatusService>();
            Bind<IRealEstateClassService>().To<RealEstateClassService>();
            Bind<IRealEstateService>().To<RealEstateService>();
            Bind<IRealEstateStatusService>().To<RealEstateStatusService>();
            Bind<IRealEstateTypeService>().To<RealEstateTypeService>();
            Bind<IRealEstateTypeWallService>().To<RealEstateTypeWallService>();
            Bind<IUserService>().To<UserService>();
            Bind(typeof(IAuthentificationService<ClaimsIdentity>)).To<AuthentificationHttpService>();
            Bind(typeof(IAuthentificationService<string>)).To<AuthentificationWPFService>();

        }
    }
}
