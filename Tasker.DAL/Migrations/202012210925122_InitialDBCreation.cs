namespace Tasker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDBCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectEntities",
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
                "dbo.ProjectTaskEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        EstimatedTime = c.Time(precision: 7),
                        Completed = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1500),
                        ProjectId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectEntities", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.TimeEntryEntities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        TimeSpent = c.Time(nullable: false, precision: 7),
                        Description = c.String(maxLength: 1500),
                        ProjectTaskId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTaskEntities", t => t.ProjectTaskId, cascadeDelete: true)
                .Index(t => t.ProjectTaskId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeEntryEntities", "ProjectTaskId", "dbo.ProjectTaskEntities");
            DropForeignKey("dbo.ProjectTaskEntities", "ProjectId", "dbo.ProjectEntities");
            DropIndex("dbo.TimeEntryEntities", new[] { "ProjectTaskId" });
            DropIndex("dbo.ProjectTaskEntities", new[] { "ProjectId" });
            DropTable("dbo.TimeEntryEntities");
            DropTable("dbo.ProjectTaskEntities");
            DropTable("dbo.ProjectEntities");
        }
    }
}
