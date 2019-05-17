using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using firstTry.ViewModel.ItemViewModels;

namespace firstTry.ViewModel
{
    class mainViewModel : Abstract.viewModel
    {
        private data dat;
        private DateTime time;
        private string timeS;

        private double czk;

        private double eur;
        private double aud;
        private double brl;
        private double bgn;
        private double cny;
        private double dkk;
        private double php;

        private double hkd;
        private double hrk;
        private double inr;
        private double usd;
        private double gbp;
        private double _try;
        private double thb;

        public mainViewModel()
        {
            dat = new data();
            time = new DateTime();
            time = dat.JavaTimeStampToDateTime();
        }

        public string Time
        {
            get { return  time.ToString(); }
            
        }
        

        public double CZK
        {
            get { return czk; }
            set
            {
                czk = value;

                foreach(KeyValuePair<string, double> item in dat.GetDataFromDB())
                {
                    switch (item.Key)
                    {
                        case "USDEUR":
                            EUR = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDAUD":
                            AUD = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDBRL":
                            BRL = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDBGN":
                            BGN = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDCNY":
                            CNY = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDDKK":
                            DKK = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDPHP":
                            PHP = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDHKD":
                            HKD = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDHRK":
                            HRK = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDINR":
                            INR = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDCZK":
                            USD = CZK / item.Value;
                            break;
                        case "USDGBP":
                            GBP = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDTRY":
                            TRY = CZK / (dat.GetCZK() / item.Value);
                            break;
                        case "USDTHB":
                            THB = CZK / (dat.GetCZK() / item.Value);
                            break;
                    }
                }
            }
        }


        public double EUR
        {
            get { return eur; }
            set { eur = value; OnPropertyChanged("EUR"); }
        }

        public double AUD
        {
            get { return aud; }
            set { aud = value; OnPropertyChanged("AUD"); }
        }
        public double BRL
        {
            get { return brl; }
            set { brl = value; OnPropertyChanged("BRL"); }
        }
        public double BGN
        {
            get { return bgn; }
            set { bgn = value; OnPropertyChanged("BGN"); }
        }
        public double CNY
        {
            get { return cny; }
            set { cny = value; OnPropertyChanged("CNY"); }
        }
        public double DKK
        {
            get { return dkk; }
            set { dkk = value; OnPropertyChanged("DKK"); }
        }
        public double PHP
        {
            get { return php; }
            set { php = value; OnPropertyChanged("PHP"); }
        }
        public double HKD
        {
            get { return hkd; }
            set { hkd = value; OnPropertyChanged("HKD"); }
        }
        public double HRK
        {
            get { return hrk; }
            set { hrk = value; OnPropertyChanged("HRK"); }
        }
        public double INR
        {
            get { return inr; }
            set { inr = value; OnPropertyChanged("INR"); }
        }
        public double USD
        {
            get { return usd; }
            set { usd = value; OnPropertyChanged("USD"); }
        }
        public double GBP
        {
            get { return gbp; }
            set { gbp = value; OnPropertyChanged("GBP"); }
        }
        public double TRY
        {
            get { return _try; }
            set { _try = value; OnPropertyChanged("TRY"); }
        }
        public double THB
        {
            get { return thb; }
            set { thb = value; OnPropertyChanged("THB"); }
        }

        

    }
}
