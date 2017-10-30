namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mg5581 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Galleries", "UserId", "dbo.Users");
            DropIndex("dbo.Galleries", new[] { "UserId" });
            AlterColumn("dbo.Galleries", "UserId", c => c.Int());
            CreateIndex("dbo.Galleries", "UserId");
            AddForeignKey("dbo.Galleries", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Galleries", "UserId", "dbo.Users");
            DropIndex("dbo.Galleries", new[] { "UserId" });
            AlterColumn("dbo.Galleries", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Galleries", "UserId");
            AddForeignKey("dbo.Galleries", "UserId", "dbo.Users", "UserID", cascadeDelete: true);
        }
    }
}
