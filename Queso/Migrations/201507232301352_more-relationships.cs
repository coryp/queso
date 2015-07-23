namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class morerelationships : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardTasks", "Board_BoardID", c => c.Int());
            AddColumn("dbo.BoardTasks", "Task_TaskID", c => c.Int());
            CreateIndex("dbo.BoardTasks", "Board_BoardID");
            CreateIndex("dbo.BoardTasks", "Task_TaskID");
            AddForeignKey("dbo.BoardTasks", "Board_BoardID", "dbo.Boards", "BoardID");
            AddForeignKey("dbo.BoardTasks", "Task_TaskID", "dbo.Tasks", "TaskID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardTasks", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.BoardTasks", "Board_BoardID", "dbo.Boards");
            DropIndex("dbo.BoardTasks", new[] { "Task_TaskID" });
            DropIndex("dbo.BoardTasks", new[] { "Board_BoardID" });
            DropColumn("dbo.BoardTasks", "Task_TaskID");
            DropColumn("dbo.BoardTasks", "Board_BoardID");
        }
    }
}
