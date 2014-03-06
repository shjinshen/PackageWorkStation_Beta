using System;
using System.Globalization;
using System.Windows.Data;

namespace AJ.DMES.PackageWorkstation.UI.Wpf.Helpers
{
    public class ListFormatConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string source = value as string;
            if(source == null) return string.Empty;
            string[] list = source.Split(',');
            string ret = string.Empty;
            foreach(string item in list)
                ret += string.Format("• {0}\r\n", item.Trim());
            return ret;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
