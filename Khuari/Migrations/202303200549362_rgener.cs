namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rgener : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "Genre_G_Id");
            DropColumn("dbo.Movies", "Genre_G_Name");
            DropColumn("dbo.Movies", "G_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "G_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_G_Name", c => c.String());
            AddColumn("dbo.Movies", "Genre_G_Id", c => c.Int(nullable: false));
        }
    }
}
