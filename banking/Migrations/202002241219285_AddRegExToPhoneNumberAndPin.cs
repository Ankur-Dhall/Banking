namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegExToPhoneNumberAndPin : DbMigration
    {
        public override void Up()
        {
            Sql("alter table Accounts add constraint chk_Pin check(Pin like '[0-9][0-9][0-9][0-9]')");
            Sql("alter table Accounts add constraint chk_Phone check(PhoneNumber like '[7-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')");
        }
        
        public override void Down()
        {
        }
    }
}
