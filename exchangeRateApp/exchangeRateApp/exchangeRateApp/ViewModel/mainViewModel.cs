using System;
using System.Collections.Generic;
using System.Text;

namespace exchangeRateApp.ViewModel
{
    using Model;
    class mainViewModel : Abstract.viewModel
    {
        private DateTime time;
        private Data data;

        public mainViewModel()
        {
            data = new Data();
            time = data.JavaTimeStampToDateTime();
        }

    }
}
