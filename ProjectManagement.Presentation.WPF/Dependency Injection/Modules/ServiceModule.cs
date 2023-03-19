using Ninject.Modules;

namespace ProjectManagement.Presentation.WPF
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UiService>().ToSelf().InSingletonScope();
        }
    }
}
