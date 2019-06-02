using System;
using System.Collections.Generic;

namespace exchangeRateApp.ViewModel.Model
{
    using DataModel;
    using Newtonsoft.Json;
    using System.Net;
    using System.Threading.Tasks;

    class Data
    {
        public static Data Instance = new Data();

        public async Task InitializeAsync()
        {
            json = new WebClient().DownloadString("http://www.apilayer.net/api/live?access_key=eed50627c9da077136be224e011a7f95&format=1");
            items = JsonConvert.DeserializeObject<ExchangeRateInfo>(json);
            changes = new List<Change>();
            convertedData = new Dictionary<string, double>();
            convertedData = await getRateValuesAsync();
            changes = await getChangesAsync();
            selected = defaultChange;
            selected2 = defaultChange;
    }

        private string json;
        private ExchangeRateInfo items;
        private Dictionary<string, double> convertedData;
        private List<Change> changes;
        protected Change selected;
        protected Change selected2;
        protected double enteredValue;

        private Task<Dictionary<string, double>> getRateValuesAsync()
        {
            return Task.Run(() =>
            {
                Dictionary<string,double> convertedDataa = new Dictionary<string, double>();
                convertedDataa = items.quotes;
                return convertedDataa;
            });
        }

        private Task<List<Change>> getChangesAsync()
        {
            return Task.Run(() => 
            {
                List<Change> changess = new List<Change>();
            foreach (KeyValuePair<string, double> item in convertedData)
            {
                changess.Add(new Change(item.Key.Substring(3,3), item.Value));
                }
                System.Threading.Thread.Sleep(4000);
                return changess;
            });
        }


        //Konstruktor            
        

        public DateTime JavaTimeStampToDateTime()
        {
            // Java timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(items.timestamp).ToLocalTime();
            return dtDateTime;
        }        

        public List<Change> Changes
        {
            get { return changes; }
            set { changes = value;  }
        }

        public Change defaultChange
        {
            get { return Changes[0]; }
        }

        public Change Selected
        {
            get { return selected; }
            set { selected = value; }
        }

        public Change Selected2
        {
            get { return selected2; }
            set { selected2 = value; }
        }

        public double EnteredValue
        {
            get { return enteredValue; }
            set { enteredValue = value; }
        }
    }
}
