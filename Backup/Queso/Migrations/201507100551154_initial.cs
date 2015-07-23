namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        CaseNumber = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.AnswerID);
            
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        BoardID = c.Int(nullable: false, identity: true),
                        CreatedAt = c.DateTime(nullable: false),
                        EndedAt = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BoardID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Active = c.Boolean(nullable: false),
                        Challenge = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TaskID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Boards");
            DropTable("dbo.Answers");
        }
    }
}
