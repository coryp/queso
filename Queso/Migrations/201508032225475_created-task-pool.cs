namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdtaskpool : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskPools",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Challenge = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskPools");
        }
    }
}
