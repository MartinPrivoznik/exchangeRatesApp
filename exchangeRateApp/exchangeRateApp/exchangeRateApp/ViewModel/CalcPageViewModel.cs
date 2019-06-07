﻿using exchangeRateApp.ViewModel.Model;
using exchangeRateApp.ViewModel.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace exchangeRateApp.ViewModel
{
    class CalcPageViewModel : Abstract.viewModel
    {
        protected string finalValue;
        protected Change selected1;
        protected Change selected2;

        public Command Calculate { get; private set; }

        public CalcPageViewModel()
        {
            Calculate = new Command(Calculate_executeAsync);
            selected1 = Data.Instance.defaultChange;
            selected2 = Data.Instance.defaultChange;
        }

        private async void Calculate_executeAsync(object obj)
        {
            double newValue = await getNewValueAsync();
            FinalValue = newValue.ToString("F2");
            OnPropertyChanged("FinalValue");
        }

        private Task<double> getNewValueAsync()
        {
            return Task.Run(() =>
            {
                double newValue;
                newValue = EnteredValue / (double.Parse(Selected1.USDValue) / double.Parse(Selected2.USDValue));
                OnPropertyChanged("FinalValue");
                return newValue;
            });
        }

        public string FinalValue
        {
            get { return finalValue; }
            set
            {
                finalValue = value;
                OnPropertyChanged("FinalValue");
            }
        }

        public double EnteredValue
        {
            get { return Data.Instance.EnteredValue; }
            set
            {
                Data.Instance.EnteredValue = value;
                OnPropertyChanged("EnteredValue");
                OnPropertyChanged("FinalValue");
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

        public Change Selected1
        {
            get { return selected1; }
            set
            {
                selected1 = value;
                OnPropertyChanged("Selected1");
                OnPropertyChanged("FinalValue");
            }
        }

        public Change Selected2
        {
            get { return selected2; }
            set
            {
                selected2 = value;
                OnPropertyChanged("Selected2");
                OnPropertyChanged("FinalValue");
            }
        }

        public string Color
        {
            get { return Data.Instance.DefaultColor; }
        }

        //public string Text
        //{
        //    get { return Data.Instance.Folder; }
        //    set { Data.Instance.Folder = value; OnPropertyChanged("Text"); }
        //}
    }
}