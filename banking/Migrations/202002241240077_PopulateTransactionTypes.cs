namespace banking.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTransactionTypes : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert TransactionTypes ON");
            Sql("insert into TransactionTypes(Id, Name) values(1, 'Withdraw')");
            Sql("insert into TransactionTypes(Id, Name) values(2, 'Deposit')");
            Sql("insert into TransactionTypes(Id, Name) values(3, 'Third Party Transfer')");
            Sql("set identity_insert TransactionTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
