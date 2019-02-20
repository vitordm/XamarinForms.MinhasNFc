using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MinhasNFc.Helpers.Layout.Converters
{
    class BackgroundSincronizadoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return IsSincronizado((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return IsSincronizado((bool)value);
        }

        private Color IsSincronizado(bool value)
        {
            return value ? Color.White : Color.Gray;
        }
    }
}
