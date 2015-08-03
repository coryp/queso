namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherunknown : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Answers", "Task_TaskID", "dbo.Tasks");
            DropIndex("dbo.Answers", new[] { "Task_TaskID" });
            DropColumn("dbo.Answers", "Task_TaskID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Answers", "Task_TaskID", c => c.Int());
            CreateIndex("dbo.Answers", "Task_TaskID");
            AddForeignKey("dbo.Answers", "Task_TaskID", "dbo.Tasks", "TaskID");
        }
    }
}
