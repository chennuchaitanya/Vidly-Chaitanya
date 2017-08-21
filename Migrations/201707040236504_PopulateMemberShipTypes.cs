namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberShipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonths,Discount) VALUES(1,0,0,0)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonths,Discount) VALUES(2,10,1,5)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonths,Discount) VALUES(3,15,3,10)");
            Sql("INSERT INTO MemberShipTypes (Id,SignupFee,DurationInMonths,Discount) VALUES(4,20,6,15)");
        }
        
        public override void Down()
        {
        }
    }
}
