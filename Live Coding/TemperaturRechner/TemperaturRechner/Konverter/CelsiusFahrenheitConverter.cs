using System.Globalization;
using System.Windows.Data;

namespace TemperaturRechner.Konverter;

public class CelsiusFahrenheitConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse($"{value}", out double celsius))
        {
            return celsius * 1.8 + 32;
        }

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse($"{value}", out double fahrenheit))
        {
            return (fahrenheit - 32) / 1.8;
        }

        return null;
    }
}