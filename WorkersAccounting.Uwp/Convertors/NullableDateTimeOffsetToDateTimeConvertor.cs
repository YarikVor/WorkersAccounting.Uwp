using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WorkersAccounting.Uwp.Convertors;

public class DateTimeOffsetToDateTimeConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value is not DateTime dateTime)
            return value;

        return new DateTimeOffset(dateTime);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        if (value is not DateTimeOffset dateTimeOffset)
            return DependencyProperty.UnsetValue;

        return dateTimeOffset.DateTime;
    }
}