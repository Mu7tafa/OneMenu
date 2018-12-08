namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "ImagePath", c => c.String(maxLength: 250));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Menus", "ImagePath");
        }
    }
}
