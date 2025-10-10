using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Rubyer.Converters
{
    /// <summary>
    /// Badge 偏移计算转换器
    /// </summary>
    public class BadgeOffsetConverter : IMultiValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double totalWidth && values[1] is double height && values[2] is double width)
            {
                double x = totalWidth - width + (height / 2);
                double y = (height / 2) * -1;
                return new Point(x, y);
            }

            return new Point();
        }

        /// <inheritdoc/>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}