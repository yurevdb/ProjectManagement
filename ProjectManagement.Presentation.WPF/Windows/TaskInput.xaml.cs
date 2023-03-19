using ProjectManagement.Core;
using System.Windows;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for TaskInput.xaml
    /// </summary>
    public partial class TaskInput : Window
    {
        public TaskInput(Pool pool)
        {
            InitializeComponent();

            ((TaskInputViewModel)DataContext).Pool = pool;
        }
    }
}
