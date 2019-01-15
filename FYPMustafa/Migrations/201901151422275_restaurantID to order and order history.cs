namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurantIDtoorderandorderhistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderHistories", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Orders", new[] { "Restaurant_RestaurantID" });
            DropIndex("dbo.OrderHistories", new[] { "Restaurant_RestaurantID" });
            RenameColumn(table: "dbo.OrderHistories", name: "Restaurant_RestaurantID", newName: "RestaurantID");
            RenameColumn(table: "dbo.Orders", name: "Restaurant_RestaurantID", newName: "RestaurantID");
            AddColumn("dbo.OrderHistories", "Quantity", c => c.String());
            AddColumn("dbo.OrderHistories", "SpecialRequirments", c => c.String());
            AlterColumn("dbo.Orders", "RestaurantID", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderHistories", "RestaurantID", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "RestaurantID");
            CreateIndex("dbo.OrderHistories", "RestaurantID");
            AddForeignKey("dbo.OrderHistories", "RestaurantID", "dbo.Restaurants", "RestaurantID", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "RestaurantID", "dbo.Restaurants", "RestaurantID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.OrderHistories", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.OrderHistories", new[] { "RestaurantID" });
            DropIndex("dbo.Orders", new[] { "RestaurantID" });
            AlterColumn("dbo.OrderHistories", "RestaurantID", c => c.Int());
            AlterColumn("dbo.Orders", "RestaurantID", c => c.Int());
            DropColumn("dbo.OrderHistories", "SpecialRequirments");
            DropColumn("dbo.OrderHistories", "Quantity");
            RenameColumn(table: "dbo.Orders", name: "RestaurantID", newName: "Restaurant_RestaurantID");
            RenameColumn(table: "dbo.OrderHistories", name: "RestaurantID", newName: "Restaurant_RestaurantID");
            CreateIndex("dbo.OrderHistories", "Restaurant_RestaurantID");
            CreateIndex("dbo.Orders", "Restaurant_RestaurantID");
            AddForeignKey("dbo.Orders", "Restaurant_RestaurantID", "dbo.Restaurants", "RestaurantID");
            AddForeignKey("dbo.OrderHistories", "Restaurant_RestaurantID", "dbo.Restaurants", "RestaurantID");
        }
    }
}
