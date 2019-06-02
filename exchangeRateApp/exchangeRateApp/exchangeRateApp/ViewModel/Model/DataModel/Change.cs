using System;
using System.Collections.Generic;
using System.Text;

namespace exchangeRateApp.ViewModel.Model.DataModel
{
    class Change : Abstract.viewModel
    {
        private string name;
        private double usdValue;
        public Change(string _name, double _usdValue)
        {
            name = _name;
            usdValue = _usdValue;
        }

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        public string USDValue
        {
            get { return usdValue.ToString("F2"); }
            set { usdValue = double.Parse(value); OnPropertyChanged("Value"); }
        }
    }
}
