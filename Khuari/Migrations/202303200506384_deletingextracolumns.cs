namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingextracolumns : DbMigration
    {
        public override void Up()
        {
           
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Gen_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_G_Name", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_G_Id", c => c.Int(nullable: false));
        }
    }
}
