using ProjectManagement.Core;
using System.Windows;

namespace ProjectManagement.Presentation.WPF
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
