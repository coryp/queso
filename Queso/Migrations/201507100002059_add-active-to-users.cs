namespace Queso.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addactivetousers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Active");
        }
    }
}
