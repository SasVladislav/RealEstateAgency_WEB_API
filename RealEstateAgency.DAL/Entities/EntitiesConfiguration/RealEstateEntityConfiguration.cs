using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class RealEstateEntityConfiguration : EntityTypeConfiguration<RealEstate>
    {
        public RealEstateEntityConfiguration()
        {
            this.HasKey<int>(r=>r.RealEstateID);
            this.Property(c => c.RealEstateID).IsRequired();


            this.HasRequired(r => r.RealEstateClass)
                .WithMany(c => c.RealEstates);

            this.HasRequired(r => r.RealEstateStatus)
                .WithMany(c => c.RealEstates);

            this.HasRequired(r => r.RealEstateType)
                 .WithMany(c => c.RealEstates);

            this.HasRequired(r => r.RealEstateTypeWall)
                .WithMany(c => c.RealEstates);

            this.HasRequired(o => o.Address)
             .WithMany()
            .HasForeignKey(a => a.AddressID)
            .WillCascadeOnDelete(false);

            this.Property(r=>r.Elevator).IsRequired();

            this.Property(r => r.Level).IsRequired();

            this.Property(r => r.GrossArea).IsRequired();

            this.Property(r => r.Image).IsOptional();

            this.Property(r => r.NearSubway).HasMaxLength(100).IsOptional();

            this.Property(r => r.NumberOfRooms).IsRequired();

            this.Property(r => r.Price).IsRequired();

        }
    }
}
