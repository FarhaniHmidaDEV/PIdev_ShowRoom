namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg558 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Galleries", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Galleries", "UserId");
            AddForeignKey("dbo.Galleries", "UserId", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galleries", "UserId", "dbo.Users");
            DropIndex("dbo.Galleries", new[] { "UserId" });
            DropColumn("dbo.Galleries", "UserId");
        }
    }
}
