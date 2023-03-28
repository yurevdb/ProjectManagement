using ProjectManagement.Presentation.Core;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfirmationPopupViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the message
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to return true
        /// </summary>
        public ICommand YesCommand { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to return false
        /// </summary>
        public ICommand NoCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="message">The message to display</param>
        public ConfirmationPopupViewModel(string message)
        {
            this.Message = message;

            YesCommand = new RelayParameterizedCommand(w => {
                Window window = (Window)w;
                window.DialogResult = true;
                window.Close();
            });
            NoCommand = new RelayParameterizedCommand(w => {
                Window window = (Window)w;
                window.DialogResult = false;
                window.Close();
            });
        }

        #endregion
    }
}
