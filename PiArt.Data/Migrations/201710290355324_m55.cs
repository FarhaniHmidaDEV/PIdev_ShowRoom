namespace PiArt.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m55 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deals",
                c => new
                    {
                        DealId = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Price = c.Single(nullable: false),
                        NomArtiste = c.String(),
                    })
                .PrimaryKey(t => t.DealId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Deals");
        }
    }
}
