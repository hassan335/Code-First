namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tt : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "C_Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Customers", "C_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "C_Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customers", "C_Id");
        }
    }
}
