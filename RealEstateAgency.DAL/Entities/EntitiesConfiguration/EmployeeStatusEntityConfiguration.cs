using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class EmployeeStatusEntityConfiguration : EntityTypeConfiguration<EmployeeStatus>
    {
        public EmployeeStatusEntityConfiguration()
        {
            //this.ToTable("Status");
            this.HasKey<int>(r => r.EmployeeStatusID);
            this.Property(c => c.EmployeeStatusID).IsRequired();

            this.Property(r => r.EmployeeStatusName).IsRequired().HasMaxLength(50);
        }
            
            
    }
}
