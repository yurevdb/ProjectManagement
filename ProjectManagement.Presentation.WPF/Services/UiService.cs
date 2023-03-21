using ProjectManagement.Core;
using System.Windows;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// Service for any UI actions
    /// </summary>
    public class UiService
    {
        /// <summary>
        /// Show the <see cref="PoolEditor"/> and return the updated <see cref="Pool"/>
        /// </summary>
        /// <param name="pool">The <see cref="Pool"/> to edit</param>
        /// <returns>The edited <see cref="Pool"/></returns>
        public Pool ShowPoolEditor(Pool pool)
        {
            // Create the pool editor and pass the pool through
            var w = new PoolEditor(pool)
            {
                Owner = Application.Current.MainWindow
            };

            // Show the pool editor
            w.ShowDialog();

            // Return the pool
            return pool;
        }

        /// <summary>
        /// Shows the <see cref="TaskInput"/> window and hides the <see cref="TaskOverview"/>
        /// </summary>
        /// <param name="pool">The <see cref="Pool"/> to use when adding tasks</param>
        public void ShowTaskInput(Pool pool)
        {
            // Hide the current window
            Application.Current.MainWindow.Hide();

            // Create the task input window
            var w = new TaskInput(pool);

            // Show the window
            w.ShowDialog();

            // Show the main window
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Shows the config window
        /// </summary>
        public void ShowConfig()
        {
            var w = new Config()
            {
                Owner = Application.Current.MainWindow
            };

            w.ShowDialog();
        }

        /// <summary>
        /// Shows the task editor window for the given <see cref="Task"/>
        /// </summary>
        /// <param name="task">The <see cref="Task"/> to edit</param>
        /// <returns>The edited <see cref="Task"/></returns>
        public Task ShowTaskEditor(Task task)
        {
            // Create window
            var w = new TaskEditor(task)
            {
                Owner = Application.Current.MainWindow
            };

            // Show window
            w.ShowDialog();

            // Return the task
            return task;
        }
    }
}
