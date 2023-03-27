namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGenreInMovie : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Movies", "Genre_G_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.Movies", "Genre_G_Name", c => c.Int(nullable: false));
            //AddColumn("dbo.Movies", "Gen_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Movies", "Gen_Id");
            //DropColumn("dbo.Movies", "Genre_G_Name");
            //DropColumn("dbo.Movies", "Genre_G_Id");
        }
    }
}
