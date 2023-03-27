using ProjectManagement.Core;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagement.Presentation.Core
{
    public class TaskStatusToTextDecorationsConverter : BaseValueConverter<TaskStatusToTextDecorationsConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((TaskStatus)value == TaskStatus.Done)
                return TextDecorations.Strikethrough;
            else
                return null;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
