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
        private string json;
        private ExchangeRateInfo items;
        private Dictionary<string, double> convertedData;
        private List<Change> changes;

        public async Task<Dictionary<string, double>> getRateValuesAsync()
        {
            //Add rates to Dictionary
            
            await new Task(() =>
            {
                convertedData = items.quotes;
            });

            return convertedData;
        }

        public async Task<List<Change>> getChangesAsync()
        {
            await new Task(() =>
            {
                foreach (KeyValuePair<string, double> item in convertedData)
                {
                    changes.Add(new Change(item.Key.Substring(3, 5)));
                }
            });
            return changes;
        }   


        //Konstruktor
        public Data()
        {
            json = new WebClient().DownloadString("http://www.apilayer.net/api/live?access_key=eed50627c9da077136be224e011a7f95&format=1");
            items = JsonConvert.DeserializeObject<ExchangeRateInfo>(json);
            changes = new List<Change>();
            convertedData = new Dictionary<string, double>();
            getChangesAsync().Wait();
            getRateValuesAsync().Wait();
        }

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
    }
}
