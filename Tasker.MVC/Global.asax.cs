﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Tasker.MVC.Models.Interface;
using Tasker.Service.Models;

namespace Tasker.MVC
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Project, IProjectModel>();
                cfg.CreateMap<Task, ITaskModel>();
                cfg.CreateMap<TimeEntry, ITimeEntryModel>();
            });

            var mapper = config.CreateMapper();

        }
    }
}
