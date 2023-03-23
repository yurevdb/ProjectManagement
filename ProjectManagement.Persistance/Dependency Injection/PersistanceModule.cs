using Ninject.Modules;

namespace ProjectManagement.Persistence
{
    public class PersistanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        }
    }
}
