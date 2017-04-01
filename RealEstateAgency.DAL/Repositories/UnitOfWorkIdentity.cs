using Microsoft.AspNet.Identity.EntityFramework;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstateAgency.DAL.Interfaces;

namespace RealEstateAgency.DAL.Repositories
{
    public class UnitOfWorkIdentity:IUnitOfWorkIdentity
    {
        protected ApplicationUserManager userManager;
        protected ApplicationRoleManager roleManager;
        public ApplicationUserManager AppUserManager
        {
            get
            {
                //return ApplicationUserManager.Create;
                return userManager;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager;
            }
        }
        public UnitOfWorkIdentity(IdentityDbContext dbContext)
        {
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(dbContext));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(dbContext));
        }
        
        
    }
}
