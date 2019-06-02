using exchangeRateApp.View;
using exchangeRateApp.ViewModel.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace exchangeRateApp
{

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new LoadingPage();
        }

        protected override async void OnStart()
        {
            var data = Data.Instance;
            await data.InitializeAsync();
            
            MainPage = new mainPage(); 
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
