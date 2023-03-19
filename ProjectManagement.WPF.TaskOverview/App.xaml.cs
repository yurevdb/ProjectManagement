using System.Windows;

namespace ProjectManagement.WPF.TaskOverview
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Application.Current.MainWindow = new TaskOverview();
            Application.Current.MainWindow.Show();
        }
    }
}
