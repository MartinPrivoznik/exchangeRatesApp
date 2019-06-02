using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace exchangeRateApp.ViewModel
{
    class StaticValuesPageViewModel : Abstract.viewModel
    {
        protected Change selected;
        public StaticValuesPageViewModel()
        {
            selected = Data.Instance.defaultChange;
        }


        public Change Selected
        {
            get { return selected; }
            set { selected = value; OnPropertyChanged("Selected"); }
        }

        public List<Change> ChangeList
        {
            get
            {
                return Data.Instance.Changes;
            }
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList"); }
        }

        public List<Change> ChangeList1
        {
            get
            {
                List<Change> temp = new List<Change>();
                for (int i = 0; i != Data.Instance.Changes.Count / 2; i++)
                {
                    temp.Add(Data.Instance.Changes[i]);
                }
                return temp;
            }
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList"); }
        }

        public List<Change> ChangeList2
        {
            get
            {
                List<Change> temp = new List<Change>();
                for (int i = Data.Instance.Changes.Count / 2; i != Data.Instance.Changes.Count; i++)
                {
                    temp.Add(Data.Instance.Changes[i]);
                }
                return temp;
            }
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList"); }
        }
    }
}
