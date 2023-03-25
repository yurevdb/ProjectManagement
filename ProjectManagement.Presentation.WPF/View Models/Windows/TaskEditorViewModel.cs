using ProjectManagement.Core;
using ProjectManagement.Persistence;
using ProjectManagement.Presentation.Core;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// The view model for the <see cref="TaskEditor"/>
    /// </summary>
    public class TaskEditorViewModel : BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The locally stored <see cref="ProjectManagement.Core.Task"/>
        /// </summary>
        private Task mTask;

        /// <summary>
        /// The locally stored <see cref="ApplicationDbContext"/>
        /// </summary>
        private readonly ApplicationDbContext context;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="ProjectManagement.Core.Task"/>
        /// </summary>
        public Task Task 
        {
            get => mTask;
            set
            {
                mTask = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to delete the <see cref="Task"/>
        /// </summary>
        public ICommand DeleteTaskCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskEditorViewModel(ApplicationDbContext context)
        {
            // Set variables
            this.context = context;

            // Set up the commands
            CloseCommand = new RelayParameterizedCommand(w => Close((Window)w));
            DeleteTaskCommand = new RelayParameterizedCommand(w => DeleteTask((Window)w));
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Save and close the given window
        /// </summary>
        /// <param name="window">The <see cref="Window"/> to close</param>
        private void Close(Window window) 
        {
            // Save the changes
            context.SaveChangesAsync();

            // Close the window
            window.Close();
        }

        /// <summary>
        /// Deletes the <see cref="Task"/> and closes the window
        /// </summary>
        /// <param name="window">The <see cref="Window"/> to close</param>
        private void DeleteTask(Window window) 
        {
            context.Remove(Task);
            context.SaveChanges();

            window.Close();
        }

        #endregion
    }
}
