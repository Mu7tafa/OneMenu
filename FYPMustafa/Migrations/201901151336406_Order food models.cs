namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orderfoodmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderHistories",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        ItemName = c.String(),
                        Restaurant_RestaurantID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantID)
                .Index(t => t.Restaurant_RestaurantID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        ItemName = c.String(),
                        Restaurant_RestaurantID = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantID)
                .Index(t => t.Restaurant_RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.OrderHistories", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Orders", new[] { "Restaurant_RestaurantID" });
            DropIndex("dbo.OrderHistories", new[] { "Restaurant_RestaurantID" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderHistories");
        }
    }
}
