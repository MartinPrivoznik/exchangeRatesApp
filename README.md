# exchangeRatesApp

- Application is able to :

```
          - Show static values of different changes
          - Convert own value to another based on selected changes
          - User can change his own preferences including default color or default change 
```

######App logic

- Application data usage is based in Singleton design pattern with async custom constructor which does following on app start : 

```
          - Reads data from json API
          - Deserialize API data
          - Load custom preferences from local storage by using PCL nugget
```

