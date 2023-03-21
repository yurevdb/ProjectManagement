using ProjectManagement.Core;
using System.Windows;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for TaskEditor.xaml
    /// </summary>
    public partial class TaskEditor : Window
    {
        public TaskEditor(Task task)
        {
            InitializeComponent();

            ((TaskEditorViewModel)DataContext).Task = task;
        }
    }
}
