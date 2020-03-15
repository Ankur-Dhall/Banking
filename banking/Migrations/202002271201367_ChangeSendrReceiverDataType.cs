namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSendrReceiverDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Sender", c => c.String());
            AlterColumn("dbo.Transactions", "Receiver", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Receiver", c => c.Int());
            AlterColumn("dbo.Transactions", "Sender", c => c.Int());
        }
    }
}
