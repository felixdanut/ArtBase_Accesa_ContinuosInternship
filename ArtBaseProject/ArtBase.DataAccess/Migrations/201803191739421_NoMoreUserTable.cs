namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoMoreUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Views", "User_Id", "dbo.User");
            DropForeignKey("dbo.Claps", "User_Id", "dbo.User");
            DropForeignKey("dbo.Bookmark", "User_Id", "dbo.User");
            DropIndex("dbo.Bookmark", new[] { "User_Id" });
            DropIndex("dbo.Claps", new[] { "User_Id" });
            DropIndex("dbo.Views", new[] { "User_Id" });
            DropTable("dbo.User");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Token = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Views", "User_Id");
            CreateIndex("dbo.Claps", "User_Id");
            CreateIndex("dbo.Bookmark", "User_Id");
            AddForeignKey("dbo.Bookmark", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Claps", "User_Id", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Views", "User_Id", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
