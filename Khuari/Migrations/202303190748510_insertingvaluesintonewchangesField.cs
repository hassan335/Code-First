namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertingvaluesintonewchangesField : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set DurationInmonths=0 where id = 1");
            Sql("update MembershipTypes set DurationInmonths=10 where id = 2");
            Sql("update MembershipTypes set DurationInmonths=15 where id = 3");
            Sql("update MembershipTypes set DurationInmonths=20 where id = 4");


        }

        public override void Down()
        {
        }
    }
}
