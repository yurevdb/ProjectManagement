using Ninject.Modules;

namespace ProjectManagement.Presentation.WPF
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
            Bind<ConfigViewModel>().ToSelf().InTransientScope();
            Bind<TaskEditorViewModel>().ToSelf().InTransientScope();
            Bind<TaskViewerViewModel>().ToSelf().InTransientScope();
        }
    }
}
