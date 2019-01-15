namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableandquantitytoorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TableNumber", c => c.String());
            AddColumn("dbo.Orders", "Quantity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Quantity");
            DropColumn("dbo.Orders", "TableNumber");
        }
    }
}
