namespace Tasker.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Tasks", "Name", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.TimeEntries", "Name", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeEntries", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Tasks", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Projects", "Name", c => c.String(maxLength: 200));
        }
    }
}
