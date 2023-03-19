using ProjectManagement.Core;
using ProjectManagement.Persistance;
using ProjectManagement.Presentation.Core;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// View model for the <see cref="TaskInput"/>
    /// </summary>
    public class TaskInputViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The locally stored task description
        /// </summary>
        private string mTaskDescription = string.Empty;

        /// <summary>
        /// The locally stored <see cref="ApplicationDbContext"/>
        /// </summary>
        private readonly ApplicationDbContext mContext;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the pool to which to add the tasks
        /// </summary>
        public Pool Pool { get; set; }

        /// <summary>
        /// Gets or sets the task description
        /// </summary>
        public string TaskDescription 
        {
            get => mTaskDescription;
            set
            {
                mTaskDescription = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to close the <see cref="TaskInput"/>
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to add the <see cref="Task"/>
        /// </summary>
        public ICommand AddCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskInputViewModel(ApplicationDbContext context)
        {
            // Set the context
            mContext = context;

            // Set the commands
            CloseCommand = new RelayParameterizedCommand(w => ((Window)w).Close());
            AddCommand = new RelayCommand(AddTask);
        }

        #endregion

        #region Private Functions

        /// <summary>
        /// Add a new task
        /// </summary>
        private async void AddTask()
        {
            // Check if description has words
            if (string.IsNullOrEmpty(TaskDescription))
                return;

            // Create the new task
            var t = new Task()
            {
                Description = TaskDescription,
                Status = TaskStatus.NotYetStarted
            };

            // Empty the description
            TaskDescription = string.Empty;

            // Add the task to the pool
            Pool.AddTask(t);

            // Add the task to the context
            mContext.Tasks.Add(t);

            // Save the context changes
            await mContext.SaveChangesAsync();
        }

        #endregion
    }
}
