namespace RealEstateAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressCity",
                c => new
                    {
                        AddressCityID = c.Int(nullable: false, identity: true),
                        AddressCityName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressCityID);
            
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressID = c.Int(nullable: false, identity: true),
                        AddressCityID = c.Int(nullable: false),
                        AddressRegionID = c.Int(nullable: false),
                        AddressStreetID = c.Int(nullable: false),
                        HomeNumber = c.String(nullable: false, maxLength: 10),
                        ApartmentNumber = c.Int(),
                    })
                .PrimaryKey(t => t.AddressID)
                .ForeignKey("dbo.AddressCity", t => t.AddressCityID, cascadeDelete: true)
                .ForeignKey("dbo.AddressRegion", t => t.AddressRegionID, cascadeDelete: true)
                .ForeignKey("dbo.AddressStreet", t => t.AddressStreetID, cascadeDelete: true)
                .Index(t => t.AddressCityID)
                .Index(t => t.AddressRegionID)
                .Index(t => t.AddressStreetID);
            
            CreateTable(
                "dbo.AddressRegion",
                c => new
                    {
                        AddressRegionID = c.Int(nullable: false, identity: true),
                        AddressRegionName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressRegionID);
            
            CreateTable(
                "dbo.AddressStreet",
                c => new
                    {
                        AddressStreetID = c.Int(nullable: false, identity: true),
                        AddressStreetName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AddressStreetID);
            
            CreateTable(
                "dbo.Contract",
                c => new
                    {
                        ContractID = c.Int(nullable: false, identity: true),
                        RealEstateID = c.Int(nullable: false),
                        BuyerID = c.String(maxLength: 128),
                        SellerID = c.String(nullable: false, maxLength: 128),
                        EmployeeID = c.String(nullable: false, maxLength: 128),
                        ContractTypeID = c.Int(nullable: false),
                        RecordDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ContractID)
                .ForeignKey("dbo.Person", t => t.BuyerID)
                .ForeignKey("dbo.ContractType", t => t.ContractTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.EmployeeID)
                .ForeignKey("dbo.RealEstate", t => t.RealEstateID, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.SellerID)
                .Index(t => t.RealEstateID)
                .Index(t => t.BuyerID)
                .Index(t => t.SellerID)
                .Index(t => t.EmployeeID)
                .Index(t => t.ContractTypeID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Patronumic = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.Int(nullable: false),
                        AddressID = c.Int(nullable: false),
                        EmployeePostID = c.Int(),
                        EmployeeStatusID = c.Int(),
                        StateOnline = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonId)
                .ForeignKey("dbo.EmployeePost", t => t.EmployeePostID, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeStatus", t => t.EmployeeStatusID, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.AddressID)
                .Index(t => t.EmployeePostID)
                .Index(t => t.EmployeeStatusID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeDismiss",
                c => new
                    {
                        EmployeeDismissId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.String(nullable: false, maxLength: 128),
                        EmploymentDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DismissDate = c.DateTime(precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.EmployeeDismissId)
                .ForeignKey("dbo.Person", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.EmployeePost",
                c => new
                    {
                        EmployeePostID = c.Int(nullable: false, identity: true),
                        EmployeePostName = c.String(nullable: false, maxLength: 100),
                        EmployeePostSalary = c.Double(),
                    })
                .PrimaryKey(t => t.EmployeePostID);
            
            CreateTable(
                "dbo.EmployeeStatus",
                c => new
                    {
                        EmployeeStatusID = c.Int(nullable: false, identity: true),
                        EmployeeStatusName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.EmployeeStatusID);
            
            CreateTable(
                "dbo.ContractType",
                c => new
                    {
                        ContractTypeID = c.Int(nullable: false, identity: true),
                        ContractTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ContractTypeID);
            
            CreateTable(
                "dbo.RealEstate",
                c => new
                    {
                        RealEstateID = c.Int(nullable: false, identity: true),
                        RealEstateStatusID = c.Int(nullable: false),
                        RealEstateTypeID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        RealEstateClassID = c.Int(nullable: false),
                        RealEstateTypeWallID = c.Int(nullable: false),
                        NumberOfRooms = c.Int(nullable: false),
                        GrossArea = c.Double(nullable: false),
                        NearSubway = c.String(maxLength: 100),
                        Elevator = c.Boolean(nullable: false),
                        Image = c.String(),
                        AddressID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RealEstateID)
                .ForeignKey("dbo.Address", t => t.AddressID)
                .ForeignKey("dbo.RealEstateClass", t => t.RealEstateClassID, cascadeDelete: true)
                .ForeignKey("dbo.RealEstateStatus", t => t.RealEstateStatusID, cascadeDelete: true)
                .ForeignKey("dbo.RealEstateType", t => t.RealEstateTypeID, cascadeDelete: true)
                .ForeignKey("dbo.RealEstateTypeWall", t => t.RealEstateTypeWallID, cascadeDelete: true)
                .Index(t => t.RealEstateStatusID)
                .Index(t => t.RealEstateTypeID)
                .Index(t => t.RealEstateClassID)
                .Index(t => t.RealEstateTypeWallID)
                .Index(t => t.AddressID);
            
            CreateTable(
                "dbo.RealEstateClass",
                c => new
                    {
                        RealEstateClassID = c.Int(nullable: false, identity: true),
                        RealEstateClassName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RealEstateClassID);
            
            CreateTable(
                "dbo.RealEstateStatus",
                c => new
                    {
                        RealEstateStatusID = c.Int(nullable: false, identity: true),
                        RealEstateStatusName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RealEstateStatusID);
            
            CreateTable(
                "dbo.RealEstateType",
                c => new
                    {
                        RealEstateTypeID = c.Int(nullable: false, identity: true),
                        RealEstateTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RealEstateTypeID);
            
            CreateTable(
                "dbo.RealEstateTypeWall",
                c => new
                    {
                        RealEstateTypeWallID = c.Int(nullable: false, identity: true),
                        RealEstateTypeWallName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RealEstateTypeWallID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Contract", "SellerID", "dbo.Person");
            DropForeignKey("dbo.Contract", "RealEstateID", "dbo.RealEstate");
            DropForeignKey("dbo.RealEstate", "RealEstateTypeWallID", "dbo.RealEstateTypeWall");
            DropForeignKey("dbo.RealEstate", "RealEstateTypeID", "dbo.RealEstateType");
            DropForeignKey("dbo.RealEstate", "RealEstateStatusID", "dbo.RealEstateStatus");
            DropForeignKey("dbo.RealEstate", "RealEstateClassID", "dbo.RealEstateClass");
            DropForeignKey("dbo.RealEstate", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Contract", "EmployeeID", "dbo.Person");
            DropForeignKey("dbo.Contract", "ContractTypeID", "dbo.ContractType");
            DropForeignKey("dbo.Contract", "BuyerID", "dbo.Person");
            DropForeignKey("dbo.Person", "EmployeeStatusID", "dbo.EmployeeStatus");
            DropForeignKey("dbo.Person", "EmployeePostID", "dbo.EmployeePost");
            DropForeignKey("dbo.EmployeeDismiss", "EmployeeId", "dbo.Person");
            DropForeignKey("dbo.Person", "PersonId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Person", "AddressID", "dbo.Address");
            DropForeignKey("dbo.Address", "AddressStreetID", "dbo.AddressStreet");
            DropForeignKey("dbo.Address", "AddressRegionID", "dbo.AddressRegion");
            DropForeignKey("dbo.Address", "AddressCityID", "dbo.AddressCity");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RealEstate", new[] { "AddressID" });
            DropIndex("dbo.RealEstate", new[] { "RealEstateTypeWallID" });
            DropIndex("dbo.RealEstate", new[] { "RealEstateClassID" });
            DropIndex("dbo.RealEstate", new[] { "RealEstateTypeID" });
            DropIndex("dbo.RealEstate", new[] { "RealEstateStatusID" });
            DropIndex("dbo.EmployeeDismiss", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Person", new[] { "EmployeeStatusID" });
            DropIndex("dbo.Person", new[] { "EmployeePostID" });
            DropIndex("dbo.Person", new[] { "AddressID" });
            DropIndex("dbo.Person", new[] { "PersonId" });
            DropIndex("dbo.Contract", new[] { "ContractTypeID" });
            DropIndex("dbo.Contract", new[] { "EmployeeID" });
            DropIndex("dbo.Contract", new[] { "SellerID" });
            DropIndex("dbo.Contract", new[] { "BuyerID" });
            DropIndex("dbo.Contract", new[] { "RealEstateID" });
            DropIndex("dbo.Address", new[] { "AddressStreetID" });
            DropIndex("dbo.Address", new[] { "AddressRegionID" });
            DropIndex("dbo.Address", new[] { "AddressCityID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RealEstateTypeWall");
            DropTable("dbo.RealEstateType");
            DropTable("dbo.RealEstateStatus");
            DropTable("dbo.RealEstateClass");
            DropTable("dbo.RealEstate");
            DropTable("dbo.ContractType");
            DropTable("dbo.EmployeeStatus");
            DropTable("dbo.EmployeePost");
            DropTable("dbo.EmployeeDismiss");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Person");
            DropTable("dbo.Contract");
            DropTable("dbo.AddressStreet");
            DropTable("dbo.AddressRegion");
            DropTable("dbo.Address");
            DropTable("dbo.AddressCity");
        }
    }
}
