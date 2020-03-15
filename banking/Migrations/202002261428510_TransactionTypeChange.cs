namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionTypeChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            DropColumn("dbo.Transactions", "TransactionTypeId");
            RenameColumn(table: "dbo.Transactions", name: "TransactionType_Id", newName: "TransactionTypeId");
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Transactions", "TransactionTypeId");
            AddForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionTypeId", "dbo.TransactionTypes");
            DropIndex("dbo.Transactions", new[] { "TransactionTypeId" });
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Byte());
            AlterColumn("dbo.Transactions", "TransactionTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Transactions", name: "TransactionTypeId", newName: "TransactionType_Id");
            AddColumn("dbo.Transactions", "TransactionTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "TransactionType_Id");
            AddForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes", "Id");
        }
    }
}
