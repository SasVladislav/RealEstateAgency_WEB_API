using System.Data.Entity;
using System.Collections.Generic;
using RealEstateAgency.DAL.Entities;
using RealEstateAgency.DAL.Interfaces;
using RealEstateAgency.DAL.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;

namespace RealEstateAgency.DAL.EF
{
    public class RealEstateDbInitializer : CreateDatabaseIfNotExists<RealEstateContext>
    {
        protected override void Seed(RealEstateContext context)
        {
            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationRoleManager roleMgr = new ApplicationRoleManager( new RoleStore<ApplicationRole>(context));
            string roleNameAdmin = "Admin";
            string roleNameEmployee = "Employee";
            string roleNameUser = "User";
            if (!roleMgr.RoleExists(roleNameAdmin))
            {
                roleMgr.Create(new ApplicationRole(roleNameAdmin));
            }
            if (!roleMgr.RoleExists(roleNameEmployee))
            {
                roleMgr.Create(new ApplicationRole(roleNameEmployee));
            }
            if (!roleMgr.RoleExists(roleNameUser))
            {
                roleMgr.Create(new ApplicationRole(roleNameUser));
            }
            
            var cities = new List<AddressCity>
            {
            new AddressCity {AddressCityName="Kharkiv" },
            new AddressCity {AddressCityName="London" }
            };
            cities.ForEach(rc => context.AddressCities.Add(rc));
            context.SaveChanges();

            var regions = new List<AddressRegion>
            {
            new AddressRegion { AddressRegionName = "Central" }
            };
            regions.ForEach(rg => context.AddressRegions.Add(rg));
            context.SaveChanges();

            var streets = new List<AddressStreet>
            {
            new AddressStreet {AddressStreetName = "Sumska" },
            new AddressStreet { AddressStreetName = "Richmond" }
            };
            streets.ForEach(rs => context.AddressStreets.Add(rs));
            context.SaveChanges();

            var addresses = new List<Address>
            {
            new Address {AddressCityID = cities.Single( i => i.AddressCityName =="London").AddressCityID,
                        AddressRegionID =regions.Single( i => i.AddressRegionName =="Central").AddressRegionID,
                        AddressStreetID =streets.Single( i => i.AddressStreetName =="Richmond").AddressStreetID,
                        HomeNumber ="37",ApartmentNumber=2},
            new Address {AddressCityID = cities.Single( i => i.AddressCityName =="Kharkiv").AddressCityID,
                        AddressRegionID =regions.Single( i => i.AddressRegionName =="Central").AddressRegionID,
                        AddressStreetID =streets.Single( i => i.AddressStreetName =="Sumska").AddressStreetID,
                        HomeNumber="1b" }
            };
            addresses.ForEach(a => context.Addresses.Add(a));
            context.SaveChanges();

            

            new List<EmployeePost> { new EmployeePost { EmployeePostName = "Broker",EmployeePostSalary=7500 } }
                                    .ForEach(ep => context.EmployeePosts.Add(ep));
            context.SaveChanges();

            new List<EmployeeStatus> { new EmployeeStatus { EmployeeStatusName= "Worker"},
                                       new EmployeeStatus {EmployeeStatusName = "Dismiss"  } }
                                     .ForEach(es => context.EmployeeStatuses.Add(es));
            context.SaveChanges();

            //--------------------------------------
            userMgr.Create(new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com" }, "123456");
            var admin = userMgr.FindByEmail("admin@gmail.com");
            userMgr.AddToRole(admin.Id, roleNameAdmin);
            context.SaveChanges();

            Employee adm = new Employee
            {
                PersonId = admin.Id,
                Name = "admin",
                Surname = "admin",
                Patronumic = "admin",
                PassportNumber = "AD131211",
                AddressID = 1,
                PhoneNumber = 12345,
                EmployeePostID = 1,
                EmployeeStatusID = 1,
                StateOnline = false
                
            };
            context.Employees.Add(adm);
            context.SaveChanges();

            new List<EmployeeDismiss> { new EmployeeDismiss { EmploymentDate = DateTime.Parse("2017-01-14"), EmployeeId = admin.Id } }
                                .ForEach(ed => context.EmployeeDismisses.Add(ed));
            context.SaveChanges();

            userMgr.Create(new ApplicationUser { UserName = "employee@gmail.com", Email = "employee@gmail.com" }, "123456");
            var employee = userMgr.FindByEmail("employee@gmail.com");
            userMgr.AddToRole(employee.Id, roleNameEmployee);
            context.SaveChanges();

            Employee emp = new Employee
            {
                PersonId = employee.Id,
                Name = "Employee",
                Surname = "Employee",
                Patronumic = "Employee",
                PassportNumber="EM548745",
                AddressID = 1,
                PhoneNumber = 300550,
                EmployeePostID = 1,
                EmployeeStatusID = 1,
                StateOnline = false

            };
            context.Employees.Add(emp);
            context.SaveChanges();

            new List<EmployeeDismiss> { new EmployeeDismiss { EmploymentDate = DateTime.Parse("2017-01-14"), EmployeeId = employee.Id } }
                                .ForEach(ed => context.EmployeeDismisses.Add(ed));
            context.SaveChanges();

            userMgr.Create(new ApplicationUser { UserName = "user@gmail", Email = "user@gmail" }, "123456");
            var userIdentity = userMgr.FindByEmail("user@gmail");
            userMgr.AddToRole(userIdentity.Id, roleNameUser);
            context.SaveChanges();
            //--------------------------------------
            User user = new User {
                PersonId = userIdentity.Id,
                Name = "Vlad",
                Surname = "Userov",
                Patronumic = "Userovich",
                PassportNumber = "US477845",
                AddressID = 2,
                PhoneNumber = 987654321 };
            context.Persons.Add(user);
            context.SaveChanges();
            new List<RealEstateClass> { new RealEstateClass {RealEstateClassName="House" } }
                                      .ForEach(rec => context.RealEstateClasses.Add(rec));
            context.SaveChanges();
            new List<RealEstateStatus> { new RealEstateStatus {RealEstateStatusName="Sold"},
                                         new RealEstateStatus {RealEstateStatusName = "Free" } }
                                      .ForEach(res => context.RealEstateStatuses.Add(res));
            context.SaveChanges();
            new List<RealEstateType> { new RealEstateType {RealEstateTypeName= "ResIDential" } }
                                      .ForEach(ret => context.RealEstateTypes.Add(ret));
            context.SaveChanges();
            new List<RealEstateTypeWall> { new RealEstateTypeWall {RealEstateTypeWallName= "Brick" } }
                                      .ForEach(retw => context.RealEstateTypeWalls.Add(retw));
            context.SaveChanges();
            new List<RealEstate> { new RealEstate {
                RealEstateClassID =1,
                RealEstateStatusID =2,
                RealEstateTypeID =1,
                RealEstateTypeWallID =1,
                Level=1,
                Elevator =false,
                NearSubway ="Undergraund",
                GrossArea =500,
                NumberOfRooms =4,
                AddressID =2,
                Price =500000} }
                                      .ForEach(re => context.RealEstates.Add(re));

            context.SaveChanges();

            new List<ContractType> { new ContractType {ContractTypeName= "Purchase" },
                                     new ContractType { ContractTypeName="Sale"} }
                                    .ForEach(ct => context.ContractTypes.Add(ct));
            context.SaveChanges();
            new List<Contract> { new Contract { ContractTypeID = 2, RealEstateID = 1, SellerID = userIdentity.Id, EmployeeID = employee.Id, RecordDate = DateTime.Now.ToShortDateString()} }
                                    .ForEach(re => context.Contracts.Add(re));
            context.SaveChanges();
        }
    }
}