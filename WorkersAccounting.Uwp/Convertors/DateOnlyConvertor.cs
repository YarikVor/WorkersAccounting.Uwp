using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace WorkersAccounting.Uwp.Convertors;

public class DateOnlyConvertor: IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var dateTime = (DateTime)value;
        return dateTime.ToShortDateString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        string str = (string)value;
        if (DateTime.TryParse(str, out DateTime result))
            return result;
        return DependencyProperty.UnsetValue;
    }
}

public class DateOnlyParameterConvertor : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        throw new NotSupportedException();
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        string str = (string)parameter;
        return DateTime.Parse(str);
    }
}
