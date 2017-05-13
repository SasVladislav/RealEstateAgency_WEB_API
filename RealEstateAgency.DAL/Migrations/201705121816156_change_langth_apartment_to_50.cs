namespace RealEstateAgency.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_langth_apartment_to_50 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Address", "HomeNumber", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Address", "HomeNumber", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
