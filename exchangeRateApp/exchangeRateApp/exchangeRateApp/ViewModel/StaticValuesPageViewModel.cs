using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System.Collections.Generic;

namespace exchangeRateApp.ViewModel
{
    class StaticValuesPageViewModel : Abstract.viewModel
    {
        protected string lastChanged;

        //Constructor
        public StaticValuesPageViewModel()
        {
            Selected = Data.Instance.defaultChange;  //Asigning default values to PROPS
            LastChanged = Data.Instance.LastUpdated.ToString();
        }


        //MVVM props

        public string LastChanged //Last time updated API datetime
        {
            get { return "Last updated : " + Data.Instance.LastUpdated.ToString(); }
            set { lastChanged = value; OnPropertyChanged("LastChanged"); }
        }

        public Change Selected  //Default selected value depending on preferences
        {
            get { return Data.Instance.Selected; }
            set { Data.Instance.Selected = value;
                OnPropertyChanged("Selected");
                OnPropertyChanged("ChangeList1");
                OnPropertyChanged("ChangeList2");
            }
        }

        public List<Change> ChangeList // List of changes from API
        {
            get
            {
                return Data.Instance.Changes;
            }
            set { Data.Instance.Changes = value; OnPropertyChanged("ChangeList"); }
        }

        public List<Change> ChangeList1  //List of changes cutted to half because of view
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

        public List<Change> ChangeList2 //List of changes cutted to half because of view
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
