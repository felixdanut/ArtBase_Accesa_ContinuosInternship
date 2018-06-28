namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeCleaned2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Claps", "User_Id", "dbo.User");
            DropForeignKey("dbo.Views", "User_Id", "dbo.User");
            AddForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Claps", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Views", "User_Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Views", "User_Id", "dbo.User");
            DropForeignKey("dbo.Claps", "User_Id", "dbo.User");
            DropForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category");
            DropForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark");
            DropForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark");
            AddForeignKey("dbo.Views", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Claps", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Bookmark", "Category_Id", "dbo.Category", "Id");
            AddForeignKey("dbo.Views", "Bookmark_Id", "dbo.Bookmark", "Id");
            AddForeignKey("dbo.Claps", "Bookmark_Id", "dbo.Bookmark", "Id");
        }
    }
}
