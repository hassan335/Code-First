namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerTableForGenerInDBFinal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "genre_G_Id");
            DropColumn("dbo.Movies", "genre_G_Name");
            DropColumn("dbo.Movies", "gen_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "gen_id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genre_G_Name", c => c.String());
            AddColumn("dbo.Movies", "genre_G_Id", c => c.Int(nullable: false));
        }
    }
}
