using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class RealEstateTypeWallEntityConfiguration : EntityTypeConfiguration<RealEstateTypeWall>
    {
        public RealEstateTypeWallEntityConfiguration()
        {
            this.HasKey<int>(r => r.RealEstateTypeWallID);
            this.Property(c => c.RealEstateTypeWallID).IsRequired();
            this.Property(r => r.RealEstateTypeWallName).IsRequired().HasMaxLength(50);
        }
    }
}
