using System;
using Tasker.DAL.Entities;
using Tasker.Common.Enums;
using System.Data.Entity;

namespace Tasker.DAL.DataAccess
{
    public class TaskerDbInit : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            InitialData(context);
            base.Seed(context);
        }

        private void InitialData(ApplicationDbContext context)
        {

            //=== 1st project ===
            ProjectEntity p = new ProjectEntity
            {
                Name = "Tend your garden",
                Description = "Project exsample. Keep your garden clean, watch out for snails running for strawberries! ",
                Completed = false,
                Priority = PriorityLevel.Low
            };
            context.Set<ProjectEntity>().Add(p);

            ProjectTaskEntity pt = new ProjectTaskEntity
            {
                Name = "Make new beds for onion",
                Description = "Consider using pallets",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("4:00"),
                DueDate = DateTime.Parse("2019-06-11"),
                Priority = PriorityLevel.High,
                Project = p
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            TimeEntryEntity te = new TimeEntryEntity
            {
                Name = "Find and transport pallets",
                Description = "Got them from John, call him in future if I need more",
                TimeSpent = TimeSpan.Parse("00:40"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Cut pallets",
                Description = "Cut by half",
                TimeSpent = TimeSpan.Parse("00:20"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Make beads",
                Description = "Make 2 of them",
                TimeSpent = TimeSpan.Parse("01:20"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            pt = new ProjectTaskEntity
            {
                Name = "Get soil for onion",
                Description = "Buy 60l",
                Completed = true,
                //EstimatedTime = TimeSpan.Parse("4:00"),
                DueDate = DateTime.Parse("2019-06-15"),
                Priority = PriorityLevel.Medium,
                Project = p
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            te = new TimeEntryEntity
            {
                Name = "Bought it at Garden Centre",
                Description = "Price is 2$/l",
                TimeSpent = TimeSpan.Parse("00:30"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);
            
            pt = new ProjectTaskEntity
            {
                Name = "Weed vegetables",
                Description = "Weed paprika, carrot, and onion.",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("20:00"),
                DueDate = DateTime.Parse("2019-07-25"),
                Priority = PriorityLevel.Low,
                Project = p
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            te = new TimeEntryEntity
            {
                Name = "Weeded paprika",
                Description = "",
                TimeSpent = TimeSpan.Parse("04:30"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Weeded carrot",
                Description = "",
                TimeSpent = TimeSpan.Parse("06:15"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Weeded onion",
                Description = "",
                TimeSpent = TimeSpan.Parse("08:50"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            pt = new ProjectTaskEntity
            {
                Name = "Prune fruits",
                Description = "Prune apples and plums.",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("06:00"),
                DueDate = DateTime.Parse("2019-07-18"),
                Priority = PriorityLevel.Low,
                Project = p
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            te = new TimeEntryEntity
            {
                Name = "Pruned apple trees",
                Description = "Pesticide spraying needed",
                TimeSpent = TimeSpan.Parse("02:50"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Pruned plum trees",
                Description = "",
                TimeSpent = TimeSpan.Parse("01:10"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            pt = new ProjectTaskEntity
            {
                Name = "Pesticide spraying",
                Description = "Pesticide spraying needed for apples, plums and pears",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("03:00"),
                DueDate = DateTime.Parse("2019-07-31"),
                Priority = PriorityLevel.High,
                Project = p
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            te = new TimeEntryEntity
            {
                Name = "Sprayed apples",
                Description = "Used 6l of pesticide",
                TimeSpent = TimeSpan.Parse("00:40"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Sprayed plums",
                Description = "Used 3l of pesticide",
                TimeSpent = TimeSpan.Parse("00:30"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            te = new TimeEntryEntity
            {
                Name = "Sprayed pears",
                Description = "Used 11l of pesticide",
                TimeSpent = TimeSpan.Parse("01:30"),
                ProjectTask = pt
            };
            context.Set<TimeEntryEntity>().Add(te);

            // === 2nd project ===
            ProjectEntity p2 = new ProjectEntity
            {
                Name = "Dummy project malesuada",
                Description = "Tristique senectus et netus et malesuada fames ac",
                Completed = true,
                DueDate = DateTime.Parse("2020-01-03"),
                Priority = PriorityLevel.High
            };
            context.Set<ProjectEntity>().Add(p2);



            // === 3rd project ===
            ProjectEntity p3 = new ProjectEntity
            {
                Name = "Dummy project placerat",
                Description = "Fusce ut placerat orci nulla pellentesque dignissim enim sit amet",
                Completed = false,
                DueDate = DateTime.Parse("2020-11-01"),
                Priority = PriorityLevel.Medium
            };
            context.Set<ProjectEntity>().Add(p3);

            // === 4th project ===
            ProjectEntity p4 = new ProjectEntity
            {
                Name = "Dummy project sagittis",
                Description = "Elementum sagittis vitae et leo duis ut diam quam nulla",
                Completed = true,
                DueDate = DateTime.Parse("2020-03-01"),
                Priority = PriorityLevel.Medium
            };
            context.Set<ProjectEntity>().Add(p4);

            // === 5th project ===
            ProjectEntity p5 = new ProjectEntity
            {
                Name = "Dummy project tristique",
                Description = "Turpis egestas integer eget aliquet nibh praesent tristique magna sit",
                Completed = true,
                DueDate = DateTime.Parse("2020-11-01"),
                Priority = PriorityLevel.Medium
            };
            context.Set<ProjectEntity>().Add(p5);

            // === 6th project ===
            ProjectEntity p6 = new ProjectEntity
            {
                Name = "Dummy project eget",
                Description = "Sagittis orci a scelerisque purus semper eget duis at tellus",
                Completed = false,
                DueDate = DateTime.Parse("2020-06-06"),
                Priority = PriorityLevel.High
            };
            context.Set<ProjectEntity>().Add(p6);

            // === 7th project ===
            ProjectEntity p7 = new ProjectEntity
            {
                Name = "Dummy project tincidunt",
                Description = "Libero id faucibus nisl tincidunt eget nullam non nisi est",
                Completed = false,
                DueDate = DateTime.Parse("2020-07-07"),
                Priority = PriorityLevel.High
            };
            context.Set<ProjectEntity>().Add(p7); 
            
            //=== ProjectTask for p2 ===
            pt = new ProjectTaskEntity
            {
                Name = "Project task vulputate",
                Description = "Quis auctor elit sed vulputate mi sit amet mauris commodo",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("04:30"),
                DueDate = DateTime.Parse("2020-05-06"),
                Priority = PriorityLevel.Medium,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task pellentesque",
                Description = "Mattis molestie a iaculis at erat pellentesque adipiscing commodo elit",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("22:30"),
                DueDate = DateTime.Parse("2020-07-30"),
                Priority = PriorityLevel.Low,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task venenatis",
                Description = "Consequat id porta nibh venenatis cras sed felis eget velit",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("00:30"),
                DueDate = DateTime.Parse("2020-09-06"),
                Priority = PriorityLevel.Low,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task metus",
                Description = "Nunc id cursus metus aliquam eleifend mi in nulla posuere",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("08:30"),
                DueDate = DateTime.Parse("2020-05-19"),
                Priority = PriorityLevel.Medium,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task purus",
                Description = "Ac tortor vitae purus faucibus ornare suspendisse sed nisi lacus",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("12:30"),
                DueDate = DateTime.Parse("2020-02-11"),
                Priority = PriorityLevel.Medium,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task bibendum",
                Description = "Malesuada bibendum arcu vitae elementum curabitur vitae nunc sed velit",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("18:30"),
                DueDate = DateTime.Parse("2020-03-18"),
                Priority = PriorityLevel.High,
                Project = p2
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            //=== ProjectTask for p3 ===
            pt = new ProjectTaskEntity
            {
                Name = "Project task adipiscing",
                Description = "Quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus urna",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("04:30"),
                DueDate = DateTime.Parse("2020-05-06"),
                Priority = PriorityLevel.Medium,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task dignissim",
                Description = "Velit dignissim sodales ut eu sem integer vitae justo egetelit dignissim sodales ut eu sem integer vitae justo eget",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("22:30"),
                DueDate = DateTime.Parse("2020-07-30"),
                Priority = PriorityLevel.Low,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task ultricies",
                Description = "Placerat duis ultricies lacus sed turpis tincidunt id aliquet risus",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("00:30"),
                DueDate = DateTime.Parse("2020-09-06"),
                Priority = PriorityLevel.Low,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task bibendum",
                Description = "Suscipit adipiscing bibendum est ultricies integer quis auctor elit sed",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("08:30"),
                DueDate = DateTime.Parse("2020-05-19"),
                Priority = PriorityLevel.Medium,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task massa",
                Description = "Massa massa ultricies mi quis hendrerit dolor magna eget est",
                Completed = true,
                EstimatedTime = TimeSpan.Parse("12:30"),
                DueDate = DateTime.Parse("2020-02-11"),
                Priority = PriorityLevel.Medium,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);

            pt = new ProjectTaskEntity
            {
                Name = "Project task habitasse",
                Description = "Turpis cursus in hac habitasse platea dictumst quisque sagittis purus",
                Completed = false,
                EstimatedTime = TimeSpan.Parse("18:30"),
                DueDate = DateTime.Parse("2020-03-18"),
                Priority = PriorityLevel.High,
                Project = p3
            };
            context.Set<ProjectTaskEntity>().Add(pt);
        }
    }
}
