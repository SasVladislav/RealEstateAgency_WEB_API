namespace RealEstateAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PassportLevel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "PassportNumber", c => c.String());
            AddColumn("dbo.RealEstate", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealEstate", "Level");
            DropColumn("dbo.Person", "PassportNumber");
        }
    }
}
