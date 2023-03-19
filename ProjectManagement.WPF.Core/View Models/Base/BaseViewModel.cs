using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjectManagement.WPF.Core
{
    /// <summary>
    /// Base for any view model
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Events

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Protected Functions

        /// <summary>
        /// Notifies that the property has been updated
        /// </summary>
        /// <param name="property">The property name that has been updated</param>
        protected void NotifyPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}
