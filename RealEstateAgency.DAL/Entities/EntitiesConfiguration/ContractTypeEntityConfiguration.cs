using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class ContractTypeEntityConfiguration : EntityTypeConfiguration<ContractType>
    {
        public ContractTypeEntityConfiguration()
        {
            this.HasKey<int>(r => r.ContractTypeID);
            this.Property(c => c.ContractTypeID).IsRequired();
            this.Property(r => r.ContractTypeName).IsRequired().HasMaxLength(50);
        }
    }
}
