using Ninject.Modules;

namespace ProjectManagement.Persistance
{
    public class PersistanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        }
    }
}
