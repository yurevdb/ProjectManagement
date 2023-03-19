using ProjectManagement.Core;
using ProjectManagement.WPF.Core;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.WPF.TaskOverview
{
    /// <summary>
    /// View model for the <see cref="PoolEditor"/>
    /// </summary>
    public class PoolEditorViewModel: BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The locally stored <see cref="Pool"/>
        /// </summary>
        private Pool mPool;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the <see cref="Pool"/>
        /// </summary>
        public Pool Pool 
        {
            get => mPool;
            set
            {
                mPool = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to save the edits
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public PoolEditorViewModel() : base()
        {
            // Setup the commands
            SaveCommand = new RelayParameterizedCommand(w => ((Window)w).Close());
        }

        #endregion
    }
}
