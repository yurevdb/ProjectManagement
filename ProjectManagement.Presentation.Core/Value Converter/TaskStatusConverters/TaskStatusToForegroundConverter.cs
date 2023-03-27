using ProjectManagement.Core;
using System;
using System.Globalization;
using System.Windows;

namespace ProjectManagement.Presentation.Core
{
    public class TaskStatusToForegroundConverter : BaseValueConverter<TaskStatusToForegroundConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TaskStatus)value == Enum.Parse<TaskStatus>(parameter?.ToString()) ? Application.Current.Resources["SecondaryTextBrush"] : Application.Current.Resources["PrimaryTextBrush"];
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
