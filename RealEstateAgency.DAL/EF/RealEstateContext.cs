using System.Data.Entity;
using RealEstateAgency.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System.Linq;
using RealEstateAgency.DAL.Entities.EntitiesConfiguration;

namespace RealEstateAgency.DAL.EF
{
   public class RealEstateContext:IdentityDbContext
    {
    
        public RealEstateContext():base("EFDbContext")
        {
            Database.SetInitializer<RealEstateContext>(new RealEstateDbInitializer());
        }

        public static RealEstateContext Create()
        {
            return new RealEstateContext();
        }
        public DbSet<AddressCity> AddressCities { get; set; }
        public DbSet<AddressRegion> AddressRegions { get; set; }
        public DbSet<AddressStreet> AddressStreets { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EmployeePost> EmployeePosts { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDismiss> EmployeeDismisses { get; set; }
        public DbSet<User> UserS { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<RealEstateClass> RealEstateClasses { get; set; }
        public DbSet<RealEstateStatus> RealEstateStatuses { get; set; }
        public DbSet<RealEstateType> RealEstateTypes { get; set; }
        public DbSet<RealEstateTypeWall> RealEstateTypeWalls { get; set; }
        public DbSet<RealEstate> RealEstates { get; set; }    
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Employee>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Employee");
            });

            modelBuilder.Entity<User>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("User");
            });
            modelBuilder.Configurations.Add(new PersonEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressCityEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressRegionEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressStreetEntityConfiguration());
            modelBuilder.Configurations.Add(new UserEntityConfiguration());           
            modelBuilder.Configurations.Add(new ContractTypeEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeDismissEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeePostEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeStatusEntityConfiguration());
            modelBuilder.Configurations.Add(new RealEstateClassEntityConfiguration());
            modelBuilder.Configurations.Add(new RealEstateEntityConfiguration());
            modelBuilder.Configurations.Add(new RealEstateStatusEntityConfiguration());
            modelBuilder.Configurations.Add(new RealEstateTypeEntityConfiguration());
            modelBuilder.Configurations.Add(new RealEstateTypeWallEntityConfiguration());           
            modelBuilder.Configurations.Add(new ApplicationUserEntityConfiguration());
            modelBuilder.Configurations.Add(new ContractEntityConfiguration());
        }
    }
}
