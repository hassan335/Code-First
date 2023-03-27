namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "genre_G_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "genre_G_Name", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "gen_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "gen_id");
            DropColumn("dbo.Movies", "genre_G_Name");
            DropColumn("dbo.Movies", "genre_G_Id");
        }
    }
}
