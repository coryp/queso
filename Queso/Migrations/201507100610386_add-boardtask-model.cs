namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboardtaskmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskBoards", "Task_TaskID", "dbo.Tasks");
            DropForeignKey("dbo.TaskBoards", "Board_BoardID", "dbo.Boards");
            DropIndex("dbo.TaskBoards", new[] { "Task_TaskID" });
            DropIndex("dbo.TaskBoards", new[] { "Board_BoardID" });
            DropTable("dbo.TaskBoards");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaskBoards",
                c => new
                    {
                        Task_TaskID = c.Int(nullable: false),
                        Board_BoardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_TaskID, t.Board_BoardID });
            
            CreateIndex("dbo.TaskBoards", "Board_BoardID");
            CreateIndex("dbo.TaskBoards", "Task_TaskID");
            AddForeignKey("dbo.TaskBoards", "Board_BoardID", "dbo.Boards", "BoardID", cascadeDelete: true);
            AddForeignKey("dbo.TaskBoards", "Task_TaskID", "dbo.Tasks", "TaskID", cascadeDelete: true);
        }
    }
}
