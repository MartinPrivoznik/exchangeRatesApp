using System;
using System.Collections.Generic;
using System.Text;

namespace exchangeRateApp.ViewModel.Model
{
    class Change
    {
        private string name;
        public Change (string _name)
        {
            name = _name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
