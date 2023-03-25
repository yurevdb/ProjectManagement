using ProjectManagement.Core;
using ProjectManagement.Persistence;
using ProjectManagement.Presentation.Core;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// The locally stored <see cref="ApplicationDbContext"/>
        /// </summary>
        private readonly ApplicationDbContext context;

        /// <summary>
        /// The locally stored task description input
        /// </summary>
        private string mTaskDescriptionInput = string.Empty;

        /// <summary>
        /// The locally stored pool that the tasks are related to
        /// </summary>
        private Pool mPool;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the tasks
        /// </summary>
        public IEnumerable<Task> Tasks => mPool?.Tasks.ToList();

        /// <summary>
        /// Gets or sets the task description input
        /// </summary>
        public string TaskDescriptionInput
        {
            get => mTaskDescriptionInput;
            set
            {
                mTaskDescriptionInput = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the task editor
        /// </summary>
        public ICommand OpenTaskEditorCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to open the popout
        /// </summary>
        public ICommand OpenPopoutCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to add a <see cref="Task"/>
        /// </summary>
        public ICommand AddTaskCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskViewerViewModel(UiService uiService, ApplicationDbContext context)
        {
            mUiService = uiService;
            this.context = context;

            OpenTaskEditorCommand = new RelayParameterizedCommand(t => OpenTaskEditor((Task)t));
            AddTaskCommand = new RelayCommand(AddTask);
            OpenPopoutCommand = new RelayCommand(OpenPopout);
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// Sets the <see cref="Tasks"/>
        /// </summary>
        /// <param name="tasks"></param>
        public void SetPool(Pool pool)
        {
            mPool = pool;
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
            // Show the task editor
            mUiService.ShowTaskEditor(task);

            // Update the task that are being held
            NotifyPropertyChanged(nameof(Tasks));
        }

        /// <summary>
        /// Adds a new <see cref="Task"/> based on the <see cref="TaskDescriptionInput"/>
        /// </summary>
        private void AddTask()
        {
            // Check if description has words
            if (string.IsNullOrEmpty(TaskDescriptionInput))
                return;

            // Create and add a new task
            var task = new Task()
            {
                Title = TaskDescriptionInput,
                Status = TaskStatus.NotYetStarted
            };

            // Add the task to the pool
            mPool.AddTask(task);

            // Save the data to the database
            context.Tasks.Add(task);
            context.SaveChangesAsync();

            // Set the description input to empty
            TaskDescriptionInput = string.Empty;

            // Notify that the collection has been updated
            NotifyPropertyChanged(nameof(Tasks));
        }

        /// <summary>
        /// Opens the pop out for task input
        /// </summary>
        private void OpenPopout()
        {
            // Show the task input with the selected pool
            mUiService.ShowTaskInput(mPool);

            // Notify any changes
            NotifyPropertyChanged(nameof(Tasks));
        }

        #endregion
    }
}
