namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboardtask : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskBoards",
                c => new
                    {
                        Task_TaskID = c.Int(nullable: false),
                        Board_BoardID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Task_TaskID, t.Board_BoardID })
                .ForeignKey("dbo.Tasks", t => t.Task_TaskID, cascadeDelete: true)
                .ForeignKey("dbo.Boards", t => t.Board_BoardID, cascadeDelete: true)
                .Index(t => t.Task_TaskID)
                .Index(t => t.Board_BoardID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TaskBoards", "Board_BoardID", "dbo.Boards");
            DropForeignKey("dbo.TaskBoards", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.TaskBoards", new[] { "Board_BoardID" });
            DropIndex("dbo.TaskBoards", new[] { "Task_TaskID" });
            DropTable("dbo.TaskBoards");
        }
    }
}
