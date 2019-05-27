using System;
using System.Collections.Generic;

namespace exchangeRateApp.ViewModel
{
    using exchangeRateApp.ViewModel.Model.DataModel;
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
        }

        public List<Change> ChangeTypesBind
        {
            get
            {
                return data.Changes;
            }
            set
            {
                data.Changes = value;
                OnPropertyChanged("ChangeTypesBind");
            }
        }

    }
}
