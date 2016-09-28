namespace FinalProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerBook", "BookId", "dbo.Book");
            DropForeignKey("dbo.CustomerBook", "CustomerId", "dbo.Customer");
            DropIndex("dbo.CustomerBook", new[] { "CustomerId" });
            DropIndex("dbo.CustomerBook", new[] { "BookId" });
            CreateTable(
                "dbo.BookCustomer",
                c => new
                    {
                        BookRefId = c.Long(nullable: false),
                        CustomerRefId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookRefId, t.CustomerRefId })
                .ForeignKey("dbo.Book", t => t.BookRefId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerRefId, cascadeDelete: true)
                .Index(t => t.BookRefId)
                .Index(t => t.CustomerRefId);
            
            DropTable("dbo.CustomerBook");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CustomerBook",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        BookId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.BookCustomer", "CustomerRefId", "dbo.Customer");
            DropForeignKey("dbo.BookCustomer", "BookRefId", "dbo.Book");
            DropIndex("dbo.BookCustomer", new[] { "CustomerRefId" });
            DropIndex("dbo.BookCustomer", new[] { "BookRefId" });
            DropTable("dbo.BookCustomer");
            CreateIndex("dbo.CustomerBook", "BookId");
            CreateIndex("dbo.CustomerBook", "CustomerId");
            AddForeignKey("dbo.CustomerBook", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerBook", "BookId", "dbo.Book", "Id", cascadeDelete: true);
        }
    }
}
