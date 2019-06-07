using System;
using System.Collections.Generic;

namespace exchangeRateApp.ViewModel.Model
{
    using DataModel;
    using Newtonsoft.Json;
    using PCLStorage;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Threading.Tasks;

    class Data
    {
        public static Data Instance = new Data();
        //Singleton usage (Object instances itself)

        //Async inicialization of singleton called from App.cs on app start
        public async Task InitializeAsync() 
        {
            json = new WebClient().DownloadString("http://www.apilayer.net/api/live?access_key=eed50627c9da077136be224e011a7f95&format=1"); //Loading API
            items = JsonConvert.DeserializeObject<ExchangeRateInfo>(json); //Reading API

            changes = new List<Change>();

            convertedData = new Dictionary<string, double>();   //Saving needed data to collections
            convertedData = await getRateValuesAsync();
            changes = await getChangesAsync();

            await PCLStorage();  //Loading Local Storage

            await getDefaultChangeAsync();   //Reading data from Local Storage
            lastUpdated = await getLastUpdatedAsync();

            selected = defaultChange; //Asigning read data to variables
            selected2 = defaultChange;
        }

        private string json;
        private ExchangeRateInfo items;
        private Dictionary<string, double> convertedData;
        private List<Change> changes;
        protected Change selected;
        protected Change selected2;
        protected double enteredValue;
        protected IFolder localFolder;
        protected IFile settingsFile;
        protected IFile defaultColorFile;
        protected string settings;
        protected string defaultColor;
        protected Change defaultchange;
        protected DateTime lastUpdated;

        public async Task PCLStorage()  //Loading Local Storage and asigning needed data
        {
            localFolder = FileSystem.Current.LocalStorage;
            settingsFile = await localFolder.CreateFileAsync("settings.txt",
                CreationCollisionOption.OpenIfExists);
            defaultColorFile = await localFolder.CreateFileAsync("defaultColor.txt",
                CreationCollisionOption.OpenIfExists);

            settings = await settingsFile.ReadAllTextAsync();
            if (settings == "")
            {
                settings = "AUD";
            }

            defaultColor = await defaultColorFile.ReadAllTextAsync();
            if (defaultColor == "")
            {
                defaultColor = "#14b0ff";
            }
        }

        private Task<DateTime> getLastUpdatedAsync()   //Getting and deserializing JavaTimeStamp data from API and transfering them to needed time
        {
            return Task.Run(() =>
            {
                // Java timestamp is seconds past epoch
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(items.timestamp).ToLocalTime();
                LastUpdated = dtDateTime;
                return dtDateTime;
            });
            
        }

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
                System.Threading.Thread.Sleep(1500); //Waiting to initialize correctly
                return changess;
            });
        }

        private Task getDefaultChangeAsync()
        {
            return Task.Run(() =>
            {
                foreach (Change item in changes)
                {
                    if (item.Name == settings)
                    {
                        defaultchange = item;
                    }
                }
            });
        } 

        public async void ChangeSettings(string change) //Methods to change default preferences in .txt files
        {
            await settingsFile.WriteAllTextAsync(change);
            settings = change;
        }
                                                           
        public async void ChangeDefaultColor(string color)  //  ^
        {                                                   // / \
            await defaultColorFile.WriteAllTextAsync(color);//  I
            defaultColor = color;                           //  I
        }


        //GLOBAL VARIABLES


        public DateTime LastUpdated
        {
            get { return lastUpdated; }
            set { lastUpdated = value; }
        }

        public List<Change> Changes
        {
            get { return changes; }
            set { changes = value;  }
        }

        public Change defaultChange
        {
            get { return defaultchange; }
            set { defaultchange = value; }
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

        public string Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        public string DefaultColor
        {
            get { return defaultColor; }
            set { defaultColor = value; }
        }
        

    }
}
