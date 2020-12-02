
using Ninject.Modules;
using Tasker.Service.Common;

namespace Tasker.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProjectService>().To<ProjectService>();
            Bind<IProjectTaskService>().To<ProjectTaskService>();
            Bind<ITimeEntryService>().To<TimeEntryService>();

        }
    }
}
