using CloundMusic2._0.Helper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CloundMusic2._0.Converter
{
    /// <summary>
    /// 描述：
    /// 作者：liufuwentao
    /// 时间：2020/8/26 15:06:41
    /// </summary>
    public class TimeSpanToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return null;
                }
                var t = (TimeSpan)value;
                return t.TotalMilliseconds;
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                return null; ;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
