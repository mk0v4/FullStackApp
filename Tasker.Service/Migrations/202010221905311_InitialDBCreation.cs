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
                        Name = c.String(maxLength: 200),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1500),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        DueDate = c.DateTime(),
                        Priority = c.Int(nullable: false),
                        EstimatedTime = c.DateTime(),
                        Completed = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1500),
                        CreationDate = c.DateTime(nullable: false),
                        Project_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
            CreateTable(
                "dbo.TimeEntries",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        TimeSpent = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1500),
                        CreationDate = c.DateTime(nullable: false),
                        Task_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.TimeEntries", "Task_Id", "dbo.Tasks");
            DropIndex("dbo.TimeEntries", new[] { "Task_Id" });
            DropIndex("dbo.Tasks", new[] { "Project_Id" });
            DropTable("dbo.TimeEntries");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
        }
    }
}
