namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedboardtasks : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "BoardTask_BoardTaskID", "dbo.BoardTasks");
            DropForeignKey("dbo.BoardTasks", "Board_BoardID", "dbo.Boards");
            DropForeignKey("dbo.BoardTasks", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.Answers", new[] { "BoardTask_BoardTaskID" });
            DropIndex("dbo.BoardTasks", new[] { "Board_BoardID" });
            DropIndex("dbo.BoardTasks", new[] { "Task_TaskID" });
            AddColumn("dbo.Tasks", "Board_BoardID", c => c.Int());
            CreateIndex("dbo.Tasks", "Board_BoardID");
            AddForeignKey("dbo.Tasks", "Board_BoardID", "dbo.Boards", "BoardID");
            DropColumn("dbo.Answers", "BoardTask_BoardTaskID");
            DropColumn("dbo.Tasks", "Active");
            DropTable("dbo.BoardTasks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BoardTasks",
                c => new
                    {
                        BoardTaskID = c.Int(nullable: false, identity: true),
                        Board_BoardID = c.Int(),
                        Task_TaskID = c.Int(),
                    })
                .PrimaryKey(t => t.BoardTaskID);
            
            AddColumn("dbo.Tasks", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Answers", "BoardTask_BoardTaskID", c => c.Int());
            DropForeignKey("dbo.Tasks", "Board_BoardID", "dbo.Boards");
            DropIndex("dbo.Tasks", new[] { "Board_BoardID" });
            DropColumn("dbo.Tasks", "Board_BoardID");
            CreateIndex("dbo.BoardTasks", "Task_TaskID");
            CreateIndex("dbo.BoardTasks", "Board_BoardID");
            CreateIndex("dbo.Answers", "BoardTask_BoardTaskID");
            AddForeignKey("dbo.BoardTasks", "Task_TaskID", "dbo.Tasks", "TaskID");
            AddForeignKey("dbo.BoardTasks", "Board_BoardID", "dbo.Boards", "BoardID");
            AddForeignKey("dbo.Answers", "BoardTask_BoardTaskID", "dbo.BoardTasks", "BoardTaskID");
        }
    }
}
