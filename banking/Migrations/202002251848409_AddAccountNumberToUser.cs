namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountNumberToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AccountNumber", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AccountNumber");
        }
    }
}
