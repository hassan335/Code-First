namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGener : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        G_Id = c.Int(nullable: false, identity: true),
                        G_Name = c.String(),
                    })
                .PrimaryKey(t => t.G_Id);
            
            AddColumn("dbo.Movies", "G_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "G_Id");
            AddForeignKey("dbo.Movies", "G_Id", "dbo.Genres", "G_Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "G_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "G_Id" });
            DropColumn("dbo.Movies", "G_Id");
            DropTable("dbo.Genres");
        }
    }
}
