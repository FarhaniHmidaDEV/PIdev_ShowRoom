namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Rents", name: "User_UserID", newName: "UserId");
            RenameIndex(table: "dbo.Rents", name: "IX_User_UserID", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rents", name: "IX_UserId", newName: "IX_User_UserID");
            RenameColumn(table: "dbo.Rents", name: "UserId", newName: "User_UserID");
        }
    }
}
