using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace RealEstateAgency.DAL.Entities.EntitiesConfiguration
{
    public class EmployeeDismissEntityConfiguration : EntityTypeConfiguration<EmployeeDismiss>
    {
        public EmployeeDismissEntityConfiguration()
        {
            this.HasKey<int>(d=>d.EmployeeDismissId);
            this.Property(c => c.EmployeeDismissId).IsRequired();

            this.HasRequired(d => d.Employee)
                .WithMany(e => e.EmployeeDismisses)
                .HasForeignKey(d=>d.EmployeeId);

            this.Property(d => d.EmploymentDate)
                .HasColumnType("datetime2");

            this.Property(d => d.DismissDate)
                .HasColumnType("datetime2");
        }
    }
}
