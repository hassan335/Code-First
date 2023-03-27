namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenerclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Gener_G_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Gener_G_Name", c => c.String());
            AddColumn("dbo.Movies", "G_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "G_Id");
            DropColumn("dbo.Movies", "Gener_G_Name");
            DropColumn("dbo.Movies", "Gener_G_Id");
        }
    }
}
