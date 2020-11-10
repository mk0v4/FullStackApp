using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Tasker.MVC.Models.Interface;
using Tasker.Service.DataAccess;
using Tasker.Service.Models;

namespace Tasker.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new TaskerDbInit());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, IProjectModel>().ReverseMap();
                cfg.CreateMap<ProjectTask, IProjectTaskModel>().ReverseMap();
                cfg.CreateMap<TimeEntry, ITimeEntryModel>().ReverseMap();
            });
        }
    }
}
