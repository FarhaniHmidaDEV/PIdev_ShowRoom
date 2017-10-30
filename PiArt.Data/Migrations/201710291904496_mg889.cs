namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg889 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Deals", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Deals", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rents", "StartDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rents", "EndDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rents", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rents", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Deals", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Deals", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
