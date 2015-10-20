namespace CarDealership.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalesTax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "SalesTax", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "SalesTax");
        }
    }
}
