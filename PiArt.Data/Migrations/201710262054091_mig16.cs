namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig16 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "lat", c => c.String());
            AlterColumn("dbo.Galleries", "lng", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "lng", c => c.Single(nullable: false));
            AlterColumn("dbo.Galleries", "lat", c => c.Single(nullable: false));
        }
    }
}
