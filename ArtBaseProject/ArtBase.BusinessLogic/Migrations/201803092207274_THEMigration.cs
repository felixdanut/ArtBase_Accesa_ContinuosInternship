namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class THEMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookmark",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        URL = c.String(),
                        DateSaved = c.DateTime(nullable: false),
                        Category_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Claps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClapsNumber = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Bookmark_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookmark", t => t.Bookmark_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Bookmark_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Views",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                        Bookmark_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookmark", t => t.Bookmark_Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Bookmark_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bookmarks_Tags",
                c => new
                    {
                        Bookmark_Id = c.Int(nullable: false),
                        Tag_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Bookmark_Id, t.Tag_Id })
                .ForeignKey("dbo.Bookmark", t => t.Bookmark_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .Index(t => t.Bookmark_Id)
                .Index(t => t.Tag_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            DropForeignKey("dbo.Bookmarks_Tags", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.Bookmarks_Tags", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Claps", "User_Id", "dbo.User");
            DropForeignKey("dbo.Views", "User_Id", "dbo.User");
            DropForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark");
            DropIndex("dbo.Bookmarks_Tags", new[] { "Tag_Id" });
            DropIndex("dbo.Bookmarks_Tags", new[] { "Bookmark_Id" });
            DropIndex("dbo.Views", new[] { "Bookmark_Id" });
            DropIndex("dbo.Views", new[] { "User_Id" });
            DropIndex("dbo.Claps", new[] { "Bookmark_Id" });
            DropIndex("dbo.Claps", new[] { "User_Id" });
            DropIndex("dbo.Bookmark", new[] { "User_Id" });
            DropIndex("dbo.Bookmark", new[] { "Category_Id" });
            DropTable("dbo.Bookmarks_Tags");
            DropTable("dbo.Tag");
            DropTable("dbo.Category");
            DropTable("dbo.Views");
            DropTable("dbo.User");
            DropTable("dbo.Claps");
            DropTable("dbo.Bookmark");
        }
    }
}
