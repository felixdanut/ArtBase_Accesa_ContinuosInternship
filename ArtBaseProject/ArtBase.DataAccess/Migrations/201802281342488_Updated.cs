namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users_Bookmarks", "UserId", "dbo.User");
            DropForeignKey("dbo.Users_Bookmarks", "BookmarkId", "dbo.Bookmark");
            DropIndex("dbo.Users_Bookmarks", new[] { "UserId" });
            DropIndex("dbo.Users_Bookmarks", new[] { "BookmarkId" });
            AddColumn("dbo.Bookmark", "User_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookmark", "User_Id");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "UserId", cascadeDelete: true);
            DropTable("dbo.Users_Bookmarks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Users_Bookmarks",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        BookmarkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.BookmarkId });
            
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            DropIndex("dbo.Bookmark", new[] { "User_Id" });
            DropColumn("dbo.Bookmark", "User_Id");
            CreateIndex("dbo.Users_Bookmarks", "BookmarkId");
            CreateIndex("dbo.Users_Bookmarks", "UserId");
            AddForeignKey("dbo.Users_Bookmarks", "BookmarkId", "dbo.Bookmark", "BookmarkId", cascadeDelete: true);
            AddForeignKey("dbo.Users_Bookmarks", "UserId", "dbo.User", "UserId", cascadeDelete: true);
        }
    }
}
