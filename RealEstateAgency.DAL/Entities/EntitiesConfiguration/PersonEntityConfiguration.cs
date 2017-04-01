using System.Data.Entity.ModelConfiguration;


namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            this.HasKey<string>(e => e.PersonId);
            this.Property(c => c.PersonId).IsRequired();

            this.HasRequired(o => o.Address)
            .WithMany()
            .HasForeignKey(a => a.AddressID)
            .WillCascadeOnDelete(false);

            this.Property(e => e.Name).IsRequired().HasMaxLength(50);
            this.Property(e => e.Surname).IsRequired().HasMaxLength(50);
            this.Property(e => e.Patronumic).IsRequired().HasMaxLength(50);
            this.Property(e => e.PhoneNumber);
            this.Property(e => e.PassportNumber);

        }
    }
}
