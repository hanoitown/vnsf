
using Ninject.Modules;
namespace Vnsf.WebHost.Infrastructure.Tasks
{
    public class TaskRegisterModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<ITaskManager>().To<TaskManager>();
        }
    }
}