using System;
using Microsoft.Maui.Controls;           
using Microsoft.Maui.Graphics;           
using System.Globalization;

namespace YogaApp.Converters
{
    using System;
    using Microsoft.Maui.Controls;
    using Microsoft.Maui.Graphics;

    namespace YogaApp.Converters
    {
        public class SpotsColorConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (value is int spots)
                {
                    if (spots == 0)
                        return Colors.Red;
                    if (spots < 5)
                        return Colors.Orange;
                    return Colors.Green;
                }
                return Colors.Black;
            }

            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
}
