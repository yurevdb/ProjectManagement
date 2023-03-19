using ProjectManagement.Core;
using System.Windows;

namespace ProjectManagement.WPF.TaskOverview
{
    /// <summary>
    /// Interaction logic for PoolEditor.xaml
    /// </summary>
    public partial class PoolEditor : Window
    {
        public PoolEditor(Pool pool)
        {
            InitializeComponent();

            ((PoolEditorViewModel)DataContext).Pool = pool;
        }
    }
}
