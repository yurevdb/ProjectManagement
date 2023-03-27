using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace ProjectManagement.Presentation.Core
{
    public class MultiHasItemsToVisibilityConverter : BaseMultiValueConverter<MultiHasItemsToVisibilityConverter>
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.All(c => ((IEnumerable<Object>)c).Any()))
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
