namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePinDataType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Accounts", "Pin", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Accounts", "Pin", c => c.Short(nullable: false));
        }
    }
}
