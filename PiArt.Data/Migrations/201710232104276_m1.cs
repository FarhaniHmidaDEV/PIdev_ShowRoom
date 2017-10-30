namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Galleries",
                c => new
                    {
                        GalleryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Price = c.Single(nullable: false),
                        lat = c.Double(nullable: false),
                        lng = c.Double(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.GalleryId);
            
            CreateTable(
                "dbo.Rents",
                c => new
                    {
                        RentId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        State = c.Int(nullable: false),
                        DescriptionRent = c.String(),
                        GalleryId = c.Int(nullable: false),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.RentId)
                .ForeignKey("dbo.Galleries", t => t.GalleryId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.GalleryId)
                .Index(t => t.User_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.Int(nullable: false),
                        LastName = c.Int(nullable: false),
                        Email = c.String(),
                        UserAddress = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        UserRole = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rents", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Rents", "GalleryId", "dbo.Galleries");
            DropIndex("dbo.Rents", new[] { "User_UserID" });
            DropIndex("dbo.Rents", new[] { "GalleryId" });
            DropTable("dbo.Users");
            DropTable("dbo.Rents");
            DropTable("dbo.Galleries");
        }
    }
}
