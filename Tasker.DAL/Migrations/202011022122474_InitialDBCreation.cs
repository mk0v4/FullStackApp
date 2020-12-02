namespace Tasker.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1500),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectTasks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        EstimatedTime = c.DateTime(),
                        Completed = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1500),
                        ProjectId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        TimeSpent = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1500),
                        ProjectTaskId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTasks", t => t.ProjectTaskId, cascadeDelete: true)
                .Index(t => t.ProjectTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntries", "ProjectTaskId", "dbo.ProjectTasks");
            DropForeignKey("dbo.ProjectTasks", "ProjectId", "dbo.Projects");
            DropIndex("dbo.TimeEntries", new[] { "ProjectTaskId" });
            DropIndex("dbo.ProjectTasks", new[] { "ProjectId" });
            DropTable("dbo.TimeEntries");
            DropTable("dbo.ProjectTasks");
            DropTable("dbo.Projects");
        }
    }
}
