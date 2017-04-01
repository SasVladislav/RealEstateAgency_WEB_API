using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class EmployeePostEntityConfiguration : EntityTypeConfiguration<EmployeePost>
    {
        public EmployeePostEntityConfiguration()
        {
            this.HasKey<int>(p=>p.EmployeePostID);
            this.Property(c => c.EmployeePostID).IsRequired();

            this.Property(p=>p.EmployeePostName).HasMaxLength(100).IsRequired();
            this.Property(p => p.EmployeePostSalary).IsOptional();
        }
    }
}
