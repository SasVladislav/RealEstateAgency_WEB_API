using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class RealEstateClassEntityConfiguration : EntityTypeConfiguration<RealEstateClass>
    {
        public RealEstateClassEntityConfiguration()
        {
            //this.ToTable("Class");
            this.HasKey<int>(r => r.RealEstateClassID);
            this.Property(c => c.RealEstateClassID).IsRequired();
            this.Property(r => r.RealEstateClassName).IsRequired().HasMaxLength(50);
        }
    }
}
