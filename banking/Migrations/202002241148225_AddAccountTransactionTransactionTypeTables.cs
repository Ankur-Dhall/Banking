namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTransactionTransactionTypeTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Pin = c.Short(nullable: false),
                        Balance = c.Int(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountNumber = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Sender = c.Int(),
                        Receiver = c.Int(),
                        Date = c.DateTime(nullable: false),
                        TransactionTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionTypeId, cascadeDelete: true)
                .Index(t => t.TransactionTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Accounts");
        }
    }
}
