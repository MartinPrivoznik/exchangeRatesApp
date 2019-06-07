using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace exchangeRateApp.ViewModel
{
    class SettingsPageViewModel : Abstract.viewModel
    {
        protected string selectedColor;
        protected Change selectedChange;
        public SettingsPageViewModel()
        {           
            SelectedColor = getDefaultColor();
            SelectedChange = Data.Instance.defaultChange;
        }

        private string getDefaultColor()
        {
            switch(Data.Instance.DefaultColor)
            {
                case "#14b0ff": return "Blue";
                case "#32d15c": return "Green";
                case "#ea1e40": return "Red";
                case "#8b09b7": return "Purple";
                case "#db0d93": return "Pink";
                case "#dce011": return "Yellow";
                default: return "Blue";
            }
        }

        private void changeColor_execute(string SelectedColor)
        {
            switch (SelectedColor)
            {
                case "Blue": Data.Instance.ChangeDefaultColor("#14b0ff"); break;
                case "Green": Data.Instance.ChangeDefaultColor("#32d15c"); break;
                case "Red": Data.Instance.ChangeDefaultColor("#ea1e40"); break;
                case "Purple": Data.Instance.ChangeDefaultColor("#8b09b7"); break;
                case "Pink": Data.Instance.ChangeDefaultColor("#db0d93"); break;
                case "Yellow": Data.Instance.ChangeDefaultColor("#dce011"); break;
            }
        }

        private void changeChange_execute(Change change)
        {
            Data.Instance.ChangeSettings(change.Name);
        }



        public string SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value;
                OnPropertyChanged("SelectedColor");
                changeColor_execute(value);
            }
        }

        public Change SelectedChange
        {
            get { return selectedChange; }
            set
            {
                selectedChange = value;
                OnPropertyChanged("SelectedChange");
                changeChange_execute(value);
            }
        }

        public List<Change> ChangeList
        {
            get
            {
                return Data.Instance.Changes;
            }
            set
            {
                Data.Instance.Changes = value;
                OnPropertyChanged("ChangeList");
            }
        }
    }
}
