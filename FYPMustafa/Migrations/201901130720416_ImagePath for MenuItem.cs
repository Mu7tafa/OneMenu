namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePathforMenuItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "ImagePath", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItems", "ImagePath");
        }
    }
}
