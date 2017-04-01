using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class AddressRegionEntityConfiguration : EntityTypeConfiguration<AddressRegion>
    {
        public AddressRegionEntityConfiguration()
        {
            //this.ToTable("Region");
            this.HasKey<int>(r=>r.AddressRegionID);
            this.Property(c => c.AddressRegionID).IsRequired();
            this.Property(r=>r.AddressRegionName).IsRequired().HasMaxLength(50);
        }
    }
}
