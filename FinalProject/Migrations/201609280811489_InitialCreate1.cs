namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookToCustomer", newName: "CustomerBook");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerBook", newName: "BookToCustomer");
        }
    }
}
