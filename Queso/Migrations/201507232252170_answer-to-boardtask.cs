namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answertoboardtask : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Answers", "BoardTaskID");
            AddColumn("dbo.Answers", "BoardTask_BoardTaskID", c => c.Int());
            CreateIndex("dbo.Answers", "BoardTask_BoardTaskID");
            AddForeignKey("dbo.Answers", "BoardTask_BoardTaskID", "dbo.BoardTasks", "BoardTaskID");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "BoardTaskID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Answers", "BoardTask_BoardTaskID", "dbo.BoardTasks");
            DropIndex("dbo.Answers", new[] { "BoardTask_BoardTaskID" });
            DropColumn("dbo.Answers", "BoardTask_BoardTaskID");
        }
    }
}
