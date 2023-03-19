using Ninject.Modules;

namespace ProjectManagement.WPF.TaskOverview
{
    /// <summary>
    /// Module for the view models
    /// </summary>
    public class ViewmodelModule : NinjectModule
    {
        /// <inheritdoc/>
        public override void Load()
        {
            Bind<TaskOverviewViewModel>().ToSelf().InTransientScope();
            Bind<PoolEditorViewModel>().ToSelf().InTransientScope();
            Bind<TaskInputViewModel>().ToSelf().InTransientScope();
        }
    }
}
