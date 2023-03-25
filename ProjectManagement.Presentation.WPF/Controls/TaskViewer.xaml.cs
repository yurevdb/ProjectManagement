using ProjectManagement.Core;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagement.Presentation.WPF
{
    /// <summary>
    /// Interaction logic for TaskViewer.xaml
    /// </summary>
    public partial class TaskViewer : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Gets or sets the tasks property
        /// </summary>
        public Pool Pool
        {
            get => (Pool)GetValue(PoolProperty);
            set => SetValue(PoolProperty, value);
        }

        // Using a DependencyProperty as the backing store for Tasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PoolProperty = DependencyProperty.Register(nameof(Pool), 
                                                                                             typeof(Pool), 
                                                                                             typeof(TaskViewer),
                                                                                             new PropertyMetadata(new Pool(), PoolPropertyChangedCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void PoolPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            if(((TaskViewer)obj).DataContext is TaskViewerViewModel vm)
            {
                vm.SetPool((Pool)e.NewValue);
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TaskViewer()
        {
            InitializeComponent();
        }

        #endregion
    }
}
