using System;
using System.Collections.Generic;

namespace exchangeRateApp.ViewModel
{
    using Model;
    class mainViewModel : Abstract.viewModel
    {
        private DateTime time;
        private Data data;
        private List<Change> list;

        public mainViewModel()
        {
            data = new Data();
            time = new DateTime();
            time = data.JavaTimeStampToDateTime();
            list = new List<Change>();
            data.getRateValuesAsync();
            data.getChangesAsync();
        }

        public List<Change> ChangeTypesBind
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
                OnPropertyChanged("ChangeTypesBind");
            }
        }

    }
}
