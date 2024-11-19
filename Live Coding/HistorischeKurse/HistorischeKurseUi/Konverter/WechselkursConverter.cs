using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace HistorischeKurseUi;

public class WechselkursConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (double.TryParse($"{values[0]}", culture.NumberFormat, out double betrag)
            && double.TryParse($"{values[1]}", culture.NumberFormat, out double rate))
        {
            return (betrag / rate);
        }

        return null; //string.Empty;

        //try
        //{
        //    double betrag = System.Convert.ToDouble(values[0]);
        //    double rate = System.Convert.ToDouble(values[1]);

        //    return (betrag / rate);
        //}
        //catch (Exception)
        //{
        //    return string.Empty;
        //}
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
