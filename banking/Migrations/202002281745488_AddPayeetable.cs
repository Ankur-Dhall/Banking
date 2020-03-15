namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayeetable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payees",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Payees");
        }
    }
}
