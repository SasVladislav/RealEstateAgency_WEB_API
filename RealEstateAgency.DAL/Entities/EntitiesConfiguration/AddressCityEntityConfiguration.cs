using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class AddressCityEntityConfiguration:EntityTypeConfiguration<AddressCity>
    {
        public AddressCityEntityConfiguration()
        {
           // this.ToTable("City");
            this.HasKey<int>(c=>c.AddressCityID);
            this.Property(c => c.AddressCityID).IsRequired();
            this.Property(c=>c.AddressCityName).IsRequired().HasMaxLength(50);
        }
    }
}
