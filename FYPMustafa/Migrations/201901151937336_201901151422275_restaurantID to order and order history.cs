namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201901151422275_restaurantIDtoorderandorderhistory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reports", "RestaurantID", "dbo.Restaurants");
            DropIndex("dbo.Reports", new[] { "RestaurantID" });
            DropTable("dbo.Reports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        ReportID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        ItemName = c.String(),
                        Reason = c.String(),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReportID);
            
            CreateIndex("dbo.Reports", "RestaurantID");
            AddForeignKey("dbo.Reports", "RestaurantID", "dbo.Restaurants", "RestaurantID", cascadeDelete: true);
        }
    }
}
