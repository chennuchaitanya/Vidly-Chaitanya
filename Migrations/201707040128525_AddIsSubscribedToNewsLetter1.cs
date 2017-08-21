namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedToNewsLetter1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsletter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsletter", c => c.Byte(nullable: false));
        }
    }
}
