namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStartingValueOfAccountNumbers : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC checkident('Accounts',RESEED,1000000000)");
        }
        
        public override void Down()
        {
        }
    }
}
