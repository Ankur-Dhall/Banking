namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypeOfId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            DropPrimaryKey("dbo.TransactionTypes");
            AddColumn("dbo.Transactions", "TransactionType_Id", c => c.Byte());
            AlterColumn("dbo.TransactionTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.TransactionTypes", "Id");
            CreateIndex("dbo.Transactions", "TransactionType_Id");
            AddForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            DropPrimaryKey("dbo.TransactionTypes");
            AlterColumn("dbo.TransactionTypes", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Transactions", "TransactionType_Id");
            AddPrimaryKey("dbo.TransactionTypes", "Id");
            CreateIndex("dbo.Transactions", "TransactionTypeId");
            AddForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes", "Id", cascadeDelete: true);
        }
    }
}
