using ProjectManagement.Core;
using ProjectManagement.Presentation.Core;
using System.Collections.Generic;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// View model for the <see cref="TaskViewer"/>
    /// </summary>
    public class TaskViewerViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The locally stored <see cref="UiService"/>
        /// </summary>
        private readonly UiService mUiService;

        /// <summary>
        /// The locally stored tasks
        /// </summary>
        private IEnumerable<Task> mTasks;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the tasks
        /// </summary>
        public IEnumerable<Task> Tasks => mTasks;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the task editor
        /// </summary>
        public ICommand OpenTaskEditorCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskViewerViewModel(UiService uiService)
        {
            mUiService = uiService;
            OpenTaskEditorCommand = new RelayParameterizedCommand(t => OpenTaskEditor((Task)t));
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Sets the <see cref="Tasks"/>
        /// </summary>
        /// <param name="tasks"></param>
        public void SetTasks(IEnumerable<Task> tasks)
        {
            mTasks = tasks;
            NotifyPropertyChanged(nameof(Tasks));
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Opens the <see cref="TaskEditor"/> with the given <see cref="Task"/>
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to edit/view</param>
        private void OpenTaskEditor(Task task)
        {
            mUiService.ShowTaskEditor(task);
        }

        #endregion
    }
}
