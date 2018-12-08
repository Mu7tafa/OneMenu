namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RestuarantIDincategories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RestaurantID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "RestaurantID");
        }
    }
}
