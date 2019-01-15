namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ordermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "SpecialRequirments", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "SpecialRequirments");
        }
    }
}
