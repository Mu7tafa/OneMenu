namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenuBit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Menus", "Type", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "Type", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.Menus", "Name", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
