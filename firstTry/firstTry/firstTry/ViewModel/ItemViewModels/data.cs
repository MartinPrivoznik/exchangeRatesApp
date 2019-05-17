using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Net;
using Newtonsoft.Json;

namespace firstTry.ViewModel.ItemViewModels
{
    class data
    {
        private string json;
        private Item items;
        private Dictionary<string, double> convertedData;
        private double czk;

        public Dictionary<string, double> GetDataFromDB()
        {

            convertedData = items.quotes;

            return convertedData;
        }


        //Konstruktor
        public data()
        {
            json = new WebClient().DownloadString("http://www.apilayer.net/api/live?access_key=eed50627c9da077136be224e011a7f95&format=1");
            items = JsonConvert.DeserializeObject<Item>(json);
            convertedData = new Dictionary<string, double>();
            czk = new double();
        }


        public double GetCZK()
        {
            foreach (KeyValuePair<string,double> item in GetDataFromDB())
            {
                if (item.Key == "USDCZK")
                {
                    czk = item.Value;
                }
            }

            return czk;
        }

        public DateTime JavaTimeStampToDateTime()
        {
            // Java timestamp is milliseconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(items.timestamp).ToLocalTime();
            return dtDateTime;
        }
    }
}