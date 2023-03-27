namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameColMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name='Pay As you Go' where id = 1");
            Sql("update MembershipTypes set Name='Monthly' where id = 2");
            Sql("update MembershipTypes set Name='Quaterly' where id = 3");
            Sql("update MembershipTypes set Name='Yearly' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
