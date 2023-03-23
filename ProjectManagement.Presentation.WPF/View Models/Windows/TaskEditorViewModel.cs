using ProjectManagement.Core;
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

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskEditorViewModel()
        {
            CloseCommand = new RelayParameterizedCommand(w => ((Window)w).Close());
        }

        #endregion
    }
}
