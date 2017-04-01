using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class RealEstateStatusEntityConfiguration : EntityTypeConfiguration<RealEstateStatus>
    {
        public RealEstateStatusEntityConfiguration()
        {
            this.HasKey<int>(r => r.RealEstateStatusID);
            this.Property(c => c.RealEstateStatusID).IsRequired();
            this.Property(r => r.RealEstateStatusName).IsRequired().HasMaxLength(50);
        }
    }
}
