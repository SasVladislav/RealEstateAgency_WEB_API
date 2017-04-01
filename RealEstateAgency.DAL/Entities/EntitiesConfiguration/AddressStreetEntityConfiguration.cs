using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class AddressStreetEntityConfiguration : EntityTypeConfiguration<AddressStreet>
    {
        public AddressStreetEntityConfiguration()
        {
           // this.ToTable("Street");
            this.HasKey<int>(r => r.AddressStreetID);
            this.Property(c => c.AddressStreetID).IsRequired();
            this.Property(r => r.AddressStreetName).IsRequired().HasMaxLength(50);
        }
    }
}
