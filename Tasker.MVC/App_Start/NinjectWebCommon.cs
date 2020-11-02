[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Tasker.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Tasker.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace Tasker.MVC.App_Start
{
    using System;
    using System.Web;
    using AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Tasker.Service.DataAccess;
    using Tasker.Service.DataAccess.Interface;
    using Tasker.Service.Models;
    using Tasker.MVC.Controllers;
    using Tasker.MVC.Controllers.Interface;
    using Tasker.MVC.Models;
    using Tasker.MVC.Models.Interface;
    using Tasker.Service.Service;
    using Tasker.Service.Service.Interface;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //TODO - inject
            kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>().InRequestScope();
            kernel.Bind(typeof(IGenericDataService<Project>)).To(typeof(GenericDataService<Project>));
            kernel.Bind<IProjectController>().To<ProjectController>();
            kernel.Bind<IProjectService>().To<ProjectService>();
            kernel.Bind<IProjectModel>().To<ProjectModel>();
            kernel.Bind<IMapper>().ToMethod(context =>
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Project, IProjectModel>().ReverseMap();
                        cfg.CreateMap<ProjectTask, IProjectTaskModel>().ReverseMap();
                        cfg.CreateMap<TimeEntry, ITimeEntryModel>().ReverseMap();
                        cfg.ConstructServicesUsing(t => kernel.Get(t));
                    });
                    return config.CreateMapper();
                }).InSingletonScope();

        }
    }
}
