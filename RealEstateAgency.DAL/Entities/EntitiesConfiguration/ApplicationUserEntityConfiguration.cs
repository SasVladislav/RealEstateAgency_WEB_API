using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class ApplicationUserEntityConfiguration:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserEntityConfiguration()
        {
            this.HasRequired(h => h.Person)
                .WithRequiredPrincipal(a=>a.ApplicationUser);
        }
    }
}
