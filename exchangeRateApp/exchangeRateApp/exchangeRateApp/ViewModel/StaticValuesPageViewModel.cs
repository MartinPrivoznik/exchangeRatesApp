using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace exchangeRateApp.ViewModel
{
    class StaticValuesPageViewModel : Abstract.viewModel
    {
        public StaticValuesPageViewModel()
        {
            Selected = Data.Instance.defaultChange;
        }

        public string LastChanged
        {
            get { return Data.Instance.JavaTimeStampToDateTime().ToString(); }
        }

        public Change Selected
        {
            get { return Data.Instance.Selected; }
            set { Data.Instance.Selected = value;
                OnPropertyChanged("Selected");
                OnPropertyChanged("ChangeList1");
                OnPropertyChanged("ChangeList2");
            }
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
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList1"); }
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
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList2"); }
        }
    }
}
