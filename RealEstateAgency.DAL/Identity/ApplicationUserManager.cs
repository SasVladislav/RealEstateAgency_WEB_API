using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace RealEstateAgency.DAL.Identity
{
   public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }
        public static ApplicationUserManager Create(
                IdentityFactoryOptions<ApplicationUserManager> options,
                IOwinContext context)
        {
            RealEstateContext db = context.Get<RealEstateContext>();
            ApplicationUserManager manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            return manager;
        }
    }
}
