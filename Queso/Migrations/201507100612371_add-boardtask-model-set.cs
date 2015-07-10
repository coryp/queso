namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboardtaskmodelset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardTasks",
                c => new
                    {
                        BoardTaskID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.BoardTaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BoardTasks");
        }
    }
}
