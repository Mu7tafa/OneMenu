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
                        CategoryID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        ItemID = c.String(nullable: false, maxLength: 128),
                        RestaurantID = c.String(maxLength: 128),
                        CategoryID = c.String(maxLength: 128),
                        Status = c.String(maxLength: 250, unicode: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(),
                        Ingredients = c.String(),
                    })
                .PrimaryKey(t => t.ItemID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.RestaurantID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        PictureID = c.String(nullable: false, maxLength: 128),
                        ItemID = c.String(maxLength: 128),
                        PictureLocation = c.String(),
                        Extension = c.String(),
                    })
                .PrimaryKey(t => t.PictureID)
                .ForeignKey("dbo.MenuItems", t => t.ItemID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestaurantID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 50, unicode: false),
                        Street = c.String(maxLength: 250, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        ZipCode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        OwnerID = c.String(),
                    })
                .PrimaryKey(t => t.RestaurantID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        MenuID = c.String(nullable: false, maxLength: 128),
                        Type = c.String(maxLength: 50, unicode: false),
                        RestaurantID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MenuID)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantID)
                .Index(t => t.RestaurantID);
            
            CreateTable(
                "dbo.UserInformations",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        RestuarantID = c.String(),
                        Name = c.String(maxLength: 50, unicode: false),
                        Gender = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        Role = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        DateOfBirth = c.DateTime(),
                        Street = c.String(maxLength: 250, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        Country = c.String(maxLength: 50, unicode: false),
                        ZipCode = c.String(maxLength: 10, fixedLength: true, unicode: false),
                        Status = c.String(maxLength: 20, fixedLength: true, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        Restaurant_RestaurantID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Restaurants", t => t.Restaurant_RestaurantID)
                .Index(t => t.Restaurant_RestaurantID);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagID = c.String(nullable: false, maxLength: 128),
                        ItemID = c.String(maxLength: 128),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagID)
                .ForeignKey("dbo.MenuItems", t => t.ItemID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Tags", "ItemID", "dbo.MenuItems");
            DropForeignKey("dbo.UserInformations", "Restaurant_RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Menus", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.MenuItems", "RestaurantID", "dbo.Restaurants");
            DropForeignKey("dbo.Pictures", "ItemID", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Tags", new[] { "ItemID" });
            DropIndex("dbo.UserInformations", new[] { "Restaurant_RestaurantID" });
            DropIndex("dbo.Menus", new[] { "RestaurantID" });
            DropIndex("dbo.Pictures", new[] { "ItemID" });
            DropIndex("dbo.MenuItems", new[] { "CategoryID" });
            DropIndex("dbo.MenuItems", new[] { "RestaurantID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Tags");
            DropTable("dbo.UserInformations");
            DropTable("dbo.Menus");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Pictures");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Categories");
        }
    }
}
