namespace ASP.NET_GROCERY_WEB_APP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalAmountAndPriceToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Orders", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "TotalAmount");
            DropColumn("dbo.OrderItems", "Price");
        }
    }
}
