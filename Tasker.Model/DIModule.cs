using Ninject.Modules;
using Tasker.Model.Common;

namespace Tasker.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProject>().To<Project>();
            Bind<IProjectTask>().To<ProjectTask>();
            Bind<ITimeEntry>().To<TimeEntry>();
        }
    }
}
