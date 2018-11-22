namespace FYPMustafa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        ItemID = c.Int(nullable: false, identity: true),
                        MenuID = c.String(),
                        CategoryID = c.String(),
                        Status = c.String(maxLength: 250, unicode: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        Ingredients = c.String(),
                        Category_CategoryID = c.Int(),
                        Menu_MenuID = c.Int(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.Menus", t => t.Menu_MenuID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Menu_MenuID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureID = c.Int(nullable: false, identity: true),
                        ItemID = c.String(),
                        PictureLocation = c.String(),
                        Extension = c.String(),
                        MenuItem_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.PictureID)
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_ItemID)
                .Index(t => t.MenuItem_ItemID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.Int(nullable: false, identity: true),
                        ItemID = c.String(),
                        TagName = c.String(),
                        MenuItem_ItemID = c.Int(),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_ItemID)
                .Index(t => t.MenuItem_ItemID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        Type = c.String(maxLength: 50, unicode: false),
                        RestaurantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MenuID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 250, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        ZipCode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RestaurantID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Gender = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        Role = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        DateOfBirth = c.DateTime(),
                        Street = c.String(maxLength: 250, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        ZipCode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        Status = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MenuItems", "Menu_MenuID", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Tags", "MenuItem_ItemID", "dbo.MenuItems");
            DropForeignKey("dbo.Pictures", "MenuItem_ItemID", "dbo.MenuItems");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropIndex("dbo.Menus", new[] { "RestaurantID" });
            DropIndex("dbo.Tags", new[] { "MenuItem_ItemID" });
            DropIndex("dbo.Pictures", new[] { "MenuItem_ItemID" });
            DropIndex("dbo.MenuItems", new[] { "Menu_MenuID" });
            DropIndex("dbo.MenuItems", new[] { "Category_CategoryID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Menus");
            DropTable("dbo.Tags");
            DropTable("dbo.Pictures");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Categories");
        }
    }
}
