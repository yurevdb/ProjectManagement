using Ninject.Modules;

namespace ProjectManagement.Persistence
{
    public class PersistenceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        }
    }
}
