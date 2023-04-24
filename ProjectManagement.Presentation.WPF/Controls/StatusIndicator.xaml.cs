using ProjectManagement.Core;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagement.Presentation.WPF;

/// <summary>
/// Interaction logic for StatusIndicator.xaml
/// </summary>
public partial class StatusIndicator : UserControl
{
    #region Dependency Properties

    /// <summary>
    /// Gets or sets the <see cref="TaskStatus"/> value
    /// </summary>
    public TaskStatus Status 
    {
        get => (TaskStatus)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }

    /// <summary>
    /// Statis <see cref="DependencyProperty"/> for the <see cref="Status"/>
    /// </summary>
    public static DependencyProperty StatusProperty = DependencyProperty.Register(nameof(Status), typeof(TaskStatus), typeof(StatusIndicator));

    #endregion

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public StatusIndicator()
    {
        InitializeComponent();
    }

    #endregion

    #region Events

    /// <summary>
    /// Not Yet Started Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        SetValue(StatusProperty, TaskStatus.NotYetStarted);
        tb.IsChecked = false;
    }

    /// <summary>
    /// In Progress Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button2_Click(object sender, RoutedEventArgs e)
    {
        SetValue(StatusProperty, TaskStatus.InProgress);
        tb.IsChecked = false;
    }

    /// <summary>
    /// Done Button
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button3_Click(object sender, RoutedEventArgs e)
    {
        SetValue(StatusProperty, TaskStatus.Done);
        tb.IsChecked = false;
    }

    #endregion
}