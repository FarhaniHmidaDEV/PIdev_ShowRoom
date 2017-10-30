namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Galleries", "lat", c => c.Single(nullable: false));
            AlterColumn("dbo.Galleries", "lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Galleries", "lng", c => c.Double(nullable: false));
            AlterColumn("dbo.Galleries", "lat", c => c.Double(nullable: false));
        }
    }
}
