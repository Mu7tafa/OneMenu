namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Itemtotagrelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Tags", "MenuItem_ItemID", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "Menu_MenuID", "dbo.Menus");
            DropIndex("dbo.MenuItems", new[] { "Category_CategoryID" });
            DropIndex("dbo.MenuItems", new[] { "Menu_MenuID" });
            DropIndex("dbo.Tags", new[] { "MenuItem_ItemID" });
            DropColumn("dbo.MenuItems", "CategoryID");
            DropColumn("dbo.MenuItems", "MenuID");
            DropColumn("dbo.Tags", "ItemID");
            RenameColumn(table: "dbo.MenuItems", name: "Category_CategoryID", newName: "CategoryID");
            RenameColumn(table: "dbo.Tags", name: "MenuItem_ItemID", newName: "ItemID");
            RenameColumn(table: "dbo.MenuItems", name: "Menu_MenuID", newName: "MenuID");
            AlterColumn("dbo.MenuItems", "MenuID", c => c.Int(nullable: false));
            AlterColumn("dbo.MenuItems", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.MenuItems", "CategoryID", c => c.Int(nullable: false));
            AlterColumn("dbo.MenuItems", "MenuID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "ItemID", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "ItemID", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "MenuID");
            CreateIndex("dbo.MenuItems", "CategoryID");
            CreateIndex("dbo.Tags", "ItemID");
            AddForeignKey("dbo.MenuItems", "CategoryID", "dbo.Categories", "CategoryID", cascadeDelete: true);
            AddForeignKey("dbo.Tags", "ItemID", "dbo.MenuItems", "ItemID", cascadeDelete: true);
            AddForeignKey("dbo.MenuItems", "MenuID", "dbo.Menus", "MenuID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuID", "dbo.Menus");
            DropForeignKey("dbo.Tags", "ItemID", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Tags", new[] { "ItemID" });
            DropIndex("dbo.MenuItems", new[] { "CategoryID" });
            DropIndex("dbo.MenuItems", new[] { "MenuID" });
            AlterColumn("dbo.Tags", "ItemID", c => c.Int());
            AlterColumn("dbo.Tags", "ItemID", c => c.String());
            AlterColumn("dbo.MenuItems", "MenuID", c => c.Int());
            AlterColumn("dbo.MenuItems", "CategoryID", c => c.Int());
            AlterColumn("dbo.MenuItems", "CategoryID", c => c.String());
            AlterColumn("dbo.MenuItems", "MenuID", c => c.String());
            RenameColumn(table: "dbo.MenuItems", name: "MenuID", newName: "Menu_MenuID");
            RenameColumn(table: "dbo.Tags", name: "ItemID", newName: "MenuItem_ItemID");
            RenameColumn(table: "dbo.MenuItems", name: "CategoryID", newName: "Category_CategoryID");
            AddColumn("dbo.Tags", "ItemID", c => c.String());
            AddColumn("dbo.MenuItems", "MenuID", c => c.String());
            AddColumn("dbo.MenuItems", "CategoryID", c => c.String());
            CreateIndex("dbo.Tags", "MenuItem_ItemID");
            CreateIndex("dbo.MenuItems", "Menu_MenuID");
            CreateIndex("dbo.MenuItems", "Category_CategoryID");
            AddForeignKey("dbo.MenuItems", "Menu_MenuID", "dbo.Menus", "MenuID");
            AddForeignKey("dbo.Tags", "MenuItem_ItemID", "dbo.MenuItems", "ItemID");
            AddForeignKey("dbo.MenuItems", "Category_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
