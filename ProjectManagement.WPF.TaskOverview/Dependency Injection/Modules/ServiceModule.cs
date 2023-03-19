using Ninject.Modules;

namespace ProjectManagement.WPF.TaskOverview
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UiService>().ToSelf().InSingletonScope();
        }
    }
}
