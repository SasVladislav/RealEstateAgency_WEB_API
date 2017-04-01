using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class ContractEntityConfiguration : EntityTypeConfiguration<Contract>
    {
        public ContractEntityConfiguration()
        {
            this.HasKey<int>(r => r.ContractID);
            this.Property(c => c.ContractID).IsRequired();

            this.HasOptional(c => c.Buyer)
                .WithMany()
                .HasForeignKey(c => c.BuyerID)
                .WillCascadeOnDelete(false);

            this.HasRequired(c => c.Seller)
                .WithMany()
                .HasForeignKey(c => c.SellerID)
            .WillCascadeOnDelete(false);

            this.HasRequired(c => c.Employee)
                .WithMany()
                .HasForeignKey(c => c.EmployeeID)
            .WillCascadeOnDelete(false);

            this.HasRequired(c => c.ContractType)
                .WithMany(ct=>ct.Contracts);

            this.Property(r => r.RecordDate).IsRequired();
        }
    }
}
