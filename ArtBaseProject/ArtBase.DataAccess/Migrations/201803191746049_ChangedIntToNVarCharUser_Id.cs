namespace ArtBase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedIntToNVarCharUser_Id : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookmark", "User_Id", c => c.String());
            AlterColumn("dbo.Claps", "User_Id", c => c.String());
            AlterColumn("dbo.Views", "User_Id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Views", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Claps", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Bookmark", "User_Id", c => c.Int(nullable: false));
        }
    }
}
