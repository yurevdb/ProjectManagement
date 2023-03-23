using ProjectManagement.Core;
using System.Collections.Generic;
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
        public IEnumerable<Task> Tasks
        {
            get => (IEnumerable<Task>)GetValue(TasksProperty);
            set => SetValue(TasksProperty, value);
        }

        // Using a DependencyProperty as the backing store for Tasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TasksProperty = DependencyProperty.Register(nameof(Tasks), 
                                                                                              typeof(IEnumerable<Task>), 
                                                                                              typeof(TaskViewer),
                                                                                              new PropertyMetadata(new List<Task>(), TasksPropertyChangedCallback));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private static void TasksPropertyChangedCallback(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ((TaskViewerViewModel)((TaskViewer)obj).DataContext).SetTasks((IEnumerable<Task>)e.NewValue);
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
