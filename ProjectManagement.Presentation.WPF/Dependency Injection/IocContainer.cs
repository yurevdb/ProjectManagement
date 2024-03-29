﻿using Ninject;
using ProjectManagement.Persistence;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// The container for the injection of control
    /// </summary>
    public class IocContainer
    {
        #region Private Members

        /// <summary>
        /// The locally stored <see cref="IKernel"/>
        /// </summary>
        private readonly IKernel mKernel;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="TaskOverview.TaskOverviewViewModel"/>
        /// </summary>
        public TaskOverviewViewModel TaskOverviewViewModel => mKernel.Get<TaskOverviewViewModel>();

        /// <summary>
        /// Gets the <see cref="TaskOverview.PoolEditorViewModel"/>
        /// </summary>
        public PoolEditorViewModel PoolEditorViewModel => mKernel.Get<PoolEditorViewModel>();

        /// <summary>
        /// Gets the <see cref="TaskOverview.TaskInputViewModel"/>
        /// </summary>
        public TaskInputViewModel TaskInputViewModel => mKernel.Get<TaskInputViewModel>();

        /// <summary>
        /// Gets the <see cref="TaskOverview.ConfigViewModel"/>
        /// </summary>
        public ConfigViewModel ConfigViewModel => mKernel.Get<ConfigViewModel>();

        /// <summary>
        /// Gets the <see cref="TaskOverview.TaskEditorViewModel"/>
        /// </summary>
        public TaskEditorViewModel TaskEditorViewModel => mKernel.Get<TaskEditorViewModel>();

        /// <summary>
        /// Gets the <see cref="TaskOverview.TaskViewerViewModel"/>
        /// </summary>
        public TaskViewerViewModel TaskViewerViewModel => mKernel.Get<TaskViewerViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public IocContainer()
        {
            // Initialize the kernel
            mKernel = new StandardKernel(new ViewmodelModule(), new ServiceModule(), new PersistenceModule());

            // Ensure the database exists
            mKernel.Get<ApplicationDbContext>().Database.EnsureCreated();
        }

        #endregion
    }
}
