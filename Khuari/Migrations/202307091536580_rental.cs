namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rental : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        customer_C_Id = c.Byte(nullable: false),
                        movie_M_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.customer_C_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.movie_M_Id, cascadeDelete: true)
                .Index(t => t.customer_C_Id)
                .Index(t => t.movie_M_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "movie_M_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "customer_C_Id", "dbo.Customers");
            DropIndex("dbo.Rentals", new[] { "movie_M_Id" });
            DropIndex("dbo.Rentals", new[] { "customer_C_Id" });
            DropTable("dbo.Rentals");
        }
    }
}
