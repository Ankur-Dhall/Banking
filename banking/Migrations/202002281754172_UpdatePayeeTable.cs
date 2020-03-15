namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePayeeTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Payees");
            DropColumn("dbo.Payees", "AccountNumber");
            DropColumn("dbo.Payees", "Name");
            AddColumn("dbo.Payees", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Payees", "SenderAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Payees", "PayeeAccountNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Payees", "PayeeName", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Payees", "Id");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Payees", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Payees", "AccountNumber", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Payees");
            DropColumn("dbo.Payees", "PayeeName");
            DropColumn("dbo.Payees", "PayeeAccountNumber");
            DropColumn("dbo.Payees", "SenderAccountNumber");
            DropColumn("dbo.Payees", "Id");
            AddPrimaryKey("dbo.Payees", "AccountNumber");
        }
    }
}
