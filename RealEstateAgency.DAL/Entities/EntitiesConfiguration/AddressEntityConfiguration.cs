using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class AddressEntityConfiguration:EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            
            this.HasKey<int>(a=>a.AddressID);
            this.Property(c => c.AddressID).IsRequired();

            this.HasRequired(c => c.AddressCity)
                .WithMany(a=>a.Addresses);
            this.HasRequired(r => r.AddressRegion)
                .WithMany(a => a.Addresses);
            this.HasRequired(s => s.AddressStreet)
                .WithMany(a => a.Addresses);
            
            this.Property(a => a.HomeNumber).HasMaxLength(10).IsRequired();
            this.Property(a => a.ApartmentNumber);
        }
    }
}
