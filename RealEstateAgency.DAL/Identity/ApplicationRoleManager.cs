using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace RealEstateAgency.DAL.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store) : base(store) { }
        
             public static ApplicationRoleManager Create(
                IdentityFactoryOptions<ApplicationRoleManager> options,
                IOwinContext context)
        {
            return new ApplicationRoleManager(new
                RoleStore<ApplicationRole>(context.Get<RealEstateContext>()));
        }
    }
    
}
