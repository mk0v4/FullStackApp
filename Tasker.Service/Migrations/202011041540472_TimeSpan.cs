namespace Tasker.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeSpan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProjectTasks", "EstimatedTime", c => c.Time(precision: 7));
            AlterColumn("dbo.TimeEntries", "TimeSpent", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TimeEntries", "TimeSpent", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectTasks", "EstimatedTime", c => c.DateTime());
        }
    }
}
