namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Bookmarks",
                c => new
                    {
                        BookmarkId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        URL = c.String(),
                        DateSaved = c.DateTime(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookmarkId)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Claps",
                c => new
                    {
                        ClapsId = c.Int(nullable: false, identity: true),
                        ClapsNb = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        BookmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClapsId)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookmarkId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        ViewId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BookmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ViewId)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookmarkId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.Users_Bookmarks",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        BookmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BookmarkId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BookmarkId);
            
            CreateTable(
                "dbo.Bookmarks_Tags",
                c => new
                    {
                        BookmarkId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookmarkId, t.TagId })
                .ForeignKey("dbo.Bookmarks", t => t.BookmarkId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .Index(t => t.BookmarkId)
                .Index(t => t.TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookmarks_Tags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.Bookmarks_Tags", "BookmarkId", "dbo.Bookmarks");
            DropForeignKey("dbo.Bookmarks", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Claps", "UserId", "dbo.Users");
            DropForeignKey("dbo.Views", "UserId", "dbo.Users");
            DropForeignKey("dbo.Views", "BookmarkId", "dbo.Bookmarks");
            DropForeignKey("dbo.Users_Bookmarks", "BookmarkId", "dbo.Bookmarks");
            DropForeignKey("dbo.Users_Bookmarks", "UserId", "dbo.Users");
            DropForeignKey("dbo.Claps", "BookmarkId", "dbo.Bookmarks");
            DropIndex("dbo.Bookmarks_Tags", new[] { "TagId" });
            DropIndex("dbo.Bookmarks_Tags", new[] { "BookmarkId" });
            DropIndex("dbo.Users_Bookmarks", new[] { "BookmarkId" });
            DropIndex("dbo.Users_Bookmarks", new[] { "UserId" });
            DropIndex("dbo.Views", new[] { "BookmarkId" });
            DropIndex("dbo.Views", new[] { "UserId" });
            DropIndex("dbo.Claps", new[] { "BookmarkId" });
            DropIndex("dbo.Claps", new[] { "UserId" });
            DropIndex("dbo.Bookmarks", new[] { "Category_Id" });
            DropTable("dbo.Bookmarks_Tags");
            DropTable("dbo.Users_Bookmarks");
            DropTable("dbo.Tags");
            DropTable("dbo.Views");
            DropTable("dbo.Users");
            DropTable("dbo.Claps");
            DropTable("dbo.Bookmarks");
            DropTable("dbo.Categories");
        }
    }
}
