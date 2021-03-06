# ExchangeRatesApp

- School project in **Xamarin Forms** using Visual studio 2019
- Application was tested on **Android version 4.4 (Kitkat)** but works either for latest versions of Android or even for IOS 
- Application is able to :

```
          - Show static values of different changes 
          - Convert own value to another based on selected changes
          - User can change his own preferences including default color or default change 
```

### App logic

- Application is designed using **MVVM pattern** for more understanding of program
- User needs to be **connected to the internet** to correctly read the *json API* and run the application
- Application data usage is based in **Singleton design pattern** with *async custom constructor* which does following on app start : 

```
          - Reads data from json API
          - Deserialize API data
          - Load custom preferences from local storage by using PCL nugget
```
- I have chosen using Singleton because of working with **TabbedPage** element so I could access and update all the data much easier

API call and deserializion is using Newtonsoft framework 

```csharp
          using Newtonsoft.Json;
          Whole_API_string = new WebClient().DownloadString("API url");
          converted_Item = JsonConvert.DeserializeObject<APIObjects>(Whole_API_string);
```

#### DATA in Singleton instance

- To overwrite preferences simply call *ChangeSettings(ownPreference)* or *ChangeDefaultColor(ownPreference)* methods stored in Singleton instance
- Otherwise reference all data from *ViewModels* to Instance  

##### File reading or creating a new one

- PCLStorage nugget allows me to read or create a new files in local storage by using *CreateFileAsync("settings.txt",CreationCollisionOption.OpenIfExists)* method
- In my code I use it to load default color of app and default change, which will be displayed :

```csharp
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
```

### App view

- App is based on **Tabbed page** which includes every single app *page* which are **Content pages**
- I'm using simple style with preferenced colors <br/>
<img src="Images/ValuesScreen.png" width = "250" />   <img src="Images/CalcScreen.png" width = "250" /> <br/>

©Martin Přívozník - SPŠSE a VOŠ Liberec 
