namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answertoboard : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Answers", "Board_BoardID", c => c.Int());
            CreateIndex("dbo.Answers", "Board_BoardID");
            AddForeignKey("dbo.Answers", "Board_BoardID", "dbo.Boards", "BoardID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Answers", "Board_BoardID", "dbo.Boards");
            DropIndex("dbo.Answers", new[] { "Board_BoardID" });
            DropColumn("dbo.Answers", "Board_BoardID");
        }
    }
}
