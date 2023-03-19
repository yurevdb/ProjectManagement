using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.Presentation.Core
{
    /// <summary>
    /// Base viewmodel for any window
    /// </summary>
    public class BaseWindowViewmodel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the caption height
        /// </summary>
        public double CaptionHeight { get; protected set; } = 30;

        /// <summary>
        /// Gets or sets the corner radius
        /// </summary>
        public double CornerRadius { get; protected set; } = 24;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to toggle the size of the window
        /// </summary>
        public ICommand ToggleCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseWindowViewmodel()
        {
            // Set up commands
            CloseCommand = new RelayParameterizedCommand(w => (w as Window)?.Close());
            MinimizeCommand = new RelayParameterizedCommand(w => ((Window)w).WindowState = WindowState.Minimized);
            ToggleCommand = new RelayParameterizedCommand(w => ((Window)w).WindowState = ((Window)w).WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
        }

        #endregion
    }
}
