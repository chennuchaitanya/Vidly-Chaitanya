namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypesWithName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MemberShipTypes set Name='Pay As you Go' where Id=1");
            Sql("UPDATE MemberShipTypes set Name='Monthly' where Id=2");
            Sql("UPDATE MemberShipTypes set Name='Quarterly' where Id=3");
            Sql("UPDATE MemberShipTypes set Name='Yearly' , DurationInMonths=12 where Id=4");
        }
        
        public override void Down()
        {
        }
    }
}