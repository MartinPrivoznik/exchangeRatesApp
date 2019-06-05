using exchangeRateApp.ViewModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace exchangeRateApp.ViewModel
{
    class SettingsPageViewModel : StaticValuesPageViewModel
    {
        protected string selectedColor;
        public SettingsPageViewModel()
        {
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

        public string SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value;
                OnPropertyChanged("SelectedColor");
                changeColor_execute(value);
            }
        }
    }
}
