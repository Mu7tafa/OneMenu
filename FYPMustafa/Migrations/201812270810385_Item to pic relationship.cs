namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Itemtopicrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pictures", "MenuItem_ItemID", "dbo.MenuItems");
            DropIndex("dbo.Pictures", new[] { "MenuItem_ItemID" });
            DropColumn("dbo.Pictures", "ItemID");
            RenameColumn(table: "dbo.Pictures", name: "MenuItem_ItemID", newName: "ItemID");
            AlterColumn("dbo.Pictures", "ItemID", c => c.Int(nullable: false));
            AlterColumn("dbo.Pictures", "ItemID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pictures", "ItemID");
            AddForeignKey("dbo.Pictures", "ItemID", "dbo.MenuItems", "ItemID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pictures", "ItemID", "dbo.MenuItems");
            DropIndex("dbo.Pictures", new[] { "ItemID" });
            AlterColumn("dbo.Pictures", "ItemID", c => c.Int());
            AlterColumn("dbo.Pictures", "ItemID", c => c.String());
            RenameColumn(table: "dbo.Pictures", name: "ItemID", newName: "MenuItem_ItemID");
            AddColumn("dbo.Pictures", "ItemID", c => c.String());
            CreateIndex("dbo.Pictures", "MenuItem_ItemID");
            AddForeignKey("dbo.Pictures", "MenuItem_ItemID", "dbo.MenuItems", "ItemID");
        }
    }
}
