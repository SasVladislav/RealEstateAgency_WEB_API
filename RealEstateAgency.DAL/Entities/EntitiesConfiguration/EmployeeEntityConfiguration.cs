using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class EmployeeEntityConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeEntityConfiguration()
        {

            this.HasRequired(e => e.EmployeePost)
                .WithMany(p=>p.Employees);

            this.HasRequired(e => e.EmployeeStatus)
               .WithMany(p => p.Employees);

            this.Property(e => e.StateOnline).IsRequired();
        }
    }
}
