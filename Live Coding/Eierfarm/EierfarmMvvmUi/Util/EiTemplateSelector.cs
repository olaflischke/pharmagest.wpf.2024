using EierfarmBl;
using System.Windows;
using System.Windows.Controls;

namespace EierfarmMvvmUi.Util
{
    public class EiTemplateSelector : DataTemplateSelector
    {
        public DataTemplate EiTemplate { get; set; }
        public DataTemplate DickesEiTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Ei ei)
            {
                if (ei.Gewicht > 73)
                    return DickesEiTemplate;
            }

            return EiTemplate;
        }
    }
}
