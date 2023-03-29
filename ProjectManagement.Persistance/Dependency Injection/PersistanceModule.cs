using Ninject.Modules;

namespace ProjectManagement.Persistence
{
    public class PersistenceModule : NinjectModule
    {
        public override void Load()
        {
            // Config first to be used in DbContext
            Bind<IConfig>().ToMethod(context => YamlConfig.Load()).InSingletonScope();

            // Db Context
            Bind<ApplicationDbContext>().ToSelf().InSingletonScope();
        }
    }
}
