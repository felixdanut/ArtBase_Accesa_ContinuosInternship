namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CodeCleaned1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "Id");
        }
    }
}
