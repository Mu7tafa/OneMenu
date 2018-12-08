namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuItemName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "Name", c => c.String(maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItems", "Name");
        }
    }
}
