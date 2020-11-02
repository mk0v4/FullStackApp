namespace Tasker.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriorityByPriorityLevel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Tasks", newName: "ProjectTasks");
            RenameColumn(table: "dbo.TimeEntries", name: "Task_Id", newName: "ProjectTask_Id");
            RenameIndex(table: "dbo.TimeEntries", name: "IX_Task_Id", newName: "IX_ProjectTask_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.TimeEntries", name: "IX_ProjectTask_Id", newName: "IX_Task_Id");
            RenameColumn(table: "dbo.TimeEntries", name: "ProjectTask_Id", newName: "Task_Id");
            RenameTable(name: "dbo.ProjectTasks", newName: "Tasks");
        }
    }
}
