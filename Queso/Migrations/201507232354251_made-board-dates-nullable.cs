namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeboarddatesnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Boards", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Boards", "EndedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Boards", "EndedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Boards", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
