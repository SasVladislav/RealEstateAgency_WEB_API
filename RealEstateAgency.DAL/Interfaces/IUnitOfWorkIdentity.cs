using RealEstateAgency.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Interfaces
{
    public interface IUnitOfWorkIdentity
    {
        ApplicationUserManager AppUserManager { get; }
        ApplicationRoleManager RoleManager { get; }
    }
}
