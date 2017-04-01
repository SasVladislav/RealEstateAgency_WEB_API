using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class RealEstateTypeEntityConfiguration : EntityTypeConfiguration<RealEstateType>
    {
        public RealEstateTypeEntityConfiguration()
        {
            this.HasKey<int>(r => r.RealEstateTypeID);
            this.Property(c => c.RealEstateTypeID).IsRequired();
            this.Property(r => r.RealEstateTypeName).IsRequired().HasMaxLength(50);
        }
    }
}
