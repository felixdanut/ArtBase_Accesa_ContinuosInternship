namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeCleaned : DbMigration
    {
        public override void Up()
        {

            DropPrimaryKey("dbo.Bookmark");
            DropPrimaryKey("dbo.Claps");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Views");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Tag");
            DropForeignKey("dbo.Claps", "BookmarkId", "dbo.Bookmark");
            DropForeignKey("dbo.Views", "BookmarkId", "dbo.Bookmark");
            DropForeignKey("dbo.Bookmarks_Tags", "BookmarkId", "dbo.Bookmark");
            DropForeignKey("dbo.Views", "UserId", "dbo.User");
            DropForeignKey("dbo.Claps", "UserId", "dbo.User");
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            DropForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Bookmarks_Tags", "TagId", "dbo.Tag");

            RenameColumn(table: "dbo.Claps", name: "BookmarkId", newName: "Bookmark_Id");
            RenameColumn(table: "dbo.Views", name: "BookmarkId", newName: "Bookmark_Id");
            RenameColumn(table: "dbo.Bookmarks_Tags", name: "BookmarkId", newName: "Bookmark_Id");
            RenameColumn(table: "dbo.Bookmarks_Tags", name: "TagId", newName: "Tag_Id");
            RenameColumn(table: "dbo.Claps", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Views", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Claps", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Claps", name: "IX_BookmarkId", newName: "IX_Bookmark_Id");
            RenameIndex(table: "dbo.Views", name: "IX_UserId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.Views", name: "IX_BookmarkId", newName: "IX_Bookmark_Id");
            RenameIndex(table: "dbo.Bookmarks_Tags", name: "IX_BookmarkId", newName: "IX_Bookmark_Id");
            RenameIndex(table: "dbo.Bookmarks_Tags", name: "IX_TagId", newName: "IX_Tag_Id");
            DropColumn("dbo.Bookmark", "BookmarkId");
            DropColumn("dbo.Claps", "ClapsId");
            DropColumn("dbo.Claps", "ClapsNb");
            DropColumn("dbo.User", "UserId");
            DropColumn("dbo.User", "UserName");
            DropColumn("dbo.Views", "ViewId");
            //DropColumn("dbo.Category", "CategoryId");
            //DropColumn("dbo.Category", "CategoryName");
            //DropColumn("dbo.Tag", "TagId");
            //DropColumn("dbo.Tag", "TagName");
            AddColumn("dbo.Bookmark", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Claps", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Claps", "ClapsNumber", c => c.Int(nullable: false));
            AddColumn("dbo.User", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.User", "Name", c => c.String());
            AddColumn("dbo.Views", "Id", c => c.Int(nullable: false, identity: true));
            //AddColumn("dbo.Category", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "Name", c => c.String());
            //AddColumn("dbo.Tag", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Tag", "Name", c => c.String());
            AddPrimaryKey("dbo.Bookmark", "Id");
            AddPrimaryKey("dbo.Claps", "Id");
            AddPrimaryKey("dbo.User", "Id");
            AddPrimaryKey("dbo.Views", "Id");
            AddPrimaryKey("dbo.Category", "Id");
            AddPrimaryKey("dbo.Tag", "Id");
            AddForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark", "Id");
            AddForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark", "Id");
            AddForeignKey("dbo.Bookmarks_Tags", "Bookmark_Id", "dbo.Bookmark", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Views", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Claps", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category", "Id");
            AddForeignKey("dbo.Bookmarks_Tags", "Tag_Id", "dbo.Tag", "Id", cascadeDelete: true);

        }
        
        public override void Down()
        {
            AddColumn("dbo.Tag", "TagName", c => c.String());
            AddColumn("dbo.Tag", "TagId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Category", "CategoryName", c => c.String());
            AddColumn("dbo.Category", "CategoryId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Views", "ViewId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.User", "UserName", c => c.String());
            AddColumn("dbo.User", "UserId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Claps", "ClapsNb", c => c.Int(nullable: false));
            AddColumn("dbo.Claps", "ClapsId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Bookmark", "BookmarkId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Bookmarks_Tags", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            DropForeignKey("dbo.Claps", "User_Id", "dbo.User");
            DropForeignKey("dbo.Views", "User_Id", "dbo.User");
            DropForeignKey("dbo.Bookmarks_Tags", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark");
            DropPrimaryKey("dbo.Tag");
            DropPrimaryKey("dbo.Category");
            DropPrimaryKey("dbo.Views");
            DropPrimaryKey("dbo.User");
            DropPrimaryKey("dbo.Claps");
            DropPrimaryKey("dbo.Bookmark");
            DropColumn("dbo.Tag", "Name");
            DropColumn("dbo.Tag", "Id");
            DropColumn("dbo.Category", "Name");
            DropColumn("dbo.Category", "Id");
            DropColumn("dbo.Views", "Id");
            DropColumn("dbo.User", "Name");
            DropColumn("dbo.User", "Id");
            DropColumn("dbo.Claps", "ClapsNumber");
            DropColumn("dbo.Claps", "Id");
            DropColumn("dbo.Bookmark", "Id");
            AddPrimaryKey("dbo.Tag", "TagId");
            AddPrimaryKey("dbo.Category", "CategoryId");
            AddPrimaryKey("dbo.Views", "ViewId");
            AddPrimaryKey("dbo.User", "UserId");
            AddPrimaryKey("dbo.Claps", "ClapsId");
            AddPrimaryKey("dbo.Bookmark", "BookmarkId");
            RenameIndex(table: "dbo.Bookmarks_Tags", name: "IX_Tag_Id", newName: "IX_TagId");
            RenameIndex(table: "dbo.Bookmarks_Tags", name: "IX_Bookmark_Id", newName: "IX_BookmarkId");
            RenameIndex(table: "dbo.Views", name: "IX_Bookmark_Id", newName: "IX_BookmarkId");
            RenameIndex(table: "dbo.Views", name: "IX_User_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.Claps", name: "IX_Bookmark_Id", newName: "IX_BookmarkId");
            RenameIndex(table: "dbo.Claps", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Views", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Claps", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.Bookmarks_Tags", name: "Tag_Id", newName: "TagId");
            RenameColumn(table: "dbo.Bookmarks_Tags", name: "Bookmark_Id", newName: "BookmarkId");
            RenameColumn(table: "dbo.Views", name: "Bookmark_Id", newName: "BookmarkId");
            RenameColumn(table: "dbo.Claps", name: "Bookmark_Id", newName: "BookmarkId");
            AddForeignKey("dbo.Bookmarks_Tags", "TagId", "dbo.Tag", "TagId", cascadeDelete: true);
            AddForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "UserId");
            AddForeignKey("dbo.Claps", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Views", "UserId", "dbo.User", "UserId");
            AddForeignKey("dbo.Bookmarks_Tags", "BookmarkId", "dbo.Bookmark", "BookmarkId", cascadeDelete: true);
            AddForeignKey("dbo.Views", "BookmarkId", "dbo.Bookmark", "BookmarkId");
            AddForeignKey("dbo.Claps", "BookmarkId", "dbo.Bookmark", "BookmarkId");
        }
    }
}
