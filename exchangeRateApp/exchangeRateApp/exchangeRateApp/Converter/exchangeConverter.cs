using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace exchangeRateApp.Converter
{
    class exchangeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string usdValue = (string)value;
            var param = parameter as Label;

            double newValue = 0;

            if (param != null)
            {
                string paramValue = param.Text;

                newValue = 1 / (double.Parse(Data.Instance.Selected.USDValue) / double.Parse(usdValue));
            }
            
            return newValue.ToString("F2");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
