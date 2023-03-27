﻿namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDOBPropertyInToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DOB");
        }
    }
}
