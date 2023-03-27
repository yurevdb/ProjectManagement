using System;
using System.Globalization;
using ProjectManagement.Core;

namespace ProjectManagement.Presentation.Core
{
    public class TaskStatusToBooleanConverter : BaseValueConverter<TaskStatusToBooleanConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TaskStatus)value == TaskStatus.Done;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return TaskStatus.Done;
            else
                return TaskStatus.NotYetStarted;
        }
    }
}
