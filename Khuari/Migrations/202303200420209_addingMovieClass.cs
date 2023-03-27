namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingMovieClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        M_Id = c.Int(nullable: false, identity: true),
                        M_Name = c.String(nullable: false, maxLength: 255),
                        ReleaseDate = c.DateTime(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        NumberInStockk = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.M_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
