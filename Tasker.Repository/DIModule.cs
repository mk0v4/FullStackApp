using Ninject.Modules;
using Tasker.DAL.DataAccess;
using Tasker.DAL.DataAccess.Interface;
using Tasker.Repository.Common;

namespace Tasker.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {

            Bind<IApplicationDbContext>().To<ApplicationDbContext>();

            Bind<IRepository>().To<Repository>();

            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<IProjectTaskRepository>().To<ProjectTaskRepository>();
            Bind<ITimeEntryRepository>().To<TimeEntryRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
