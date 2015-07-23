namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class no0idea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "BoardTaskID", c => c.Int(nullable: false));
            AddColumn("dbo.Answers", "User_UserID", c => c.Int());
            CreateIndex("dbo.Answers", "User_UserID");
            AddForeignKey("dbo.Answers", "User_UserID", "dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "User_UserID", "dbo.Users");
            DropIndex("dbo.Answers", new[] { "User_UserID" });
            DropColumn("dbo.Answers", "User_UserID");
            DropColumn("dbo.Answers", "BoardTaskID");
        }
    }
}
