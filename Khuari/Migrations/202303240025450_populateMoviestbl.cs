namespace Khuari.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMoviestbl : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies values ('Krish','2023-09-20 10:34:09 AM','2023-06-25 10:34:09 AM',5,2)");
            Sql("insert into Movies values('Money Heist','2023-06-20 10:34:09 AM','2023-06-25 10:34:09 AM',6,1)");
            Sql("insert into Movies values('Money Heist','2023-06-20 10:34:09 AM','2023-06-25 10:34:09 AM',5,3)");
            Sql("insert into Movies values('Money Heist','2023-06-20 10:34:09 AM','2023-06-25 10:34:09 AM',4,1)");
            Sql("insert into Movies values('Money Heist','2023-06-20 10:34:09 AM','2023-06-25 10:34:09 AM',7,2)");


        }
        
        public override void Down()
        {
        }
    }
}
