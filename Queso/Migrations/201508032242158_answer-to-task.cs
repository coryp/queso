namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class answertotask : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Board_BoardID", "dbo.Boards");
            DropIndex("dbo.Answers", new[] { "Board_BoardID" });
            AddColumn("dbo.Answers", "Task_TaskID", c => c.Int());
            CreateIndex("dbo.Answers", "Task_TaskID");
            AddForeignKey("dbo.Answers", "Task_TaskID", "dbo.Tasks", "TaskID");
            DropColumn("dbo.Answers", "Board_BoardID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Board_BoardID", c => c.Int());
            DropForeignKey("dbo.Answers", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.Answers", new[] { "Task_TaskID" });
            DropColumn("dbo.Answers", "Task_TaskID");
            CreateIndex("dbo.Answers", "Board_BoardID");
            AddForeignKey("dbo.Answers", "Board_BoardID", "dbo.Boards", "BoardID");
        }
    }
}
