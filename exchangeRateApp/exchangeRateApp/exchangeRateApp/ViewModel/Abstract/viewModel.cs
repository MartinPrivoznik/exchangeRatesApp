﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace exchangeRateApp.ViewModel.Abstract
{
    class viewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
