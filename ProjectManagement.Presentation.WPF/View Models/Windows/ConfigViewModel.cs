using ProjectManagement.Persistence;
using ProjectManagement.Presentation.Core;
using System.Windows;
using System.Windows.Input;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// View Model for the <see cref="Config"/>
    /// </summary>
    public class ConfigViewModel: BaseViewModel
    {
        #region Private Members

        /// <summary>
        /// The locally stored <see cref="IConfig"/>
        /// </summary>
        private readonly IConfig mConfig;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the <see cref="IConfig"/>
        /// </summary>
        public IConfig Config => mConfig;

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the <see cref="ICommand"/> to save and close the configuration
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConfigViewModel(IConfig config)
        {
            // Set the config
            mConfig = config;

            // Set up the commands
            SaveCommand = new RelayParameterizedCommand(w =>
            {
                mConfig.Save();
                ((Window)w).Close();
            });
        }

        #endregion
    }
}
