using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.PlatformConfiguration;
using FFImageLoading;
using FFImageLoading.Svg;
using FFImageLoading.Svg.Forms;
using System.Xml.Linq;



namespace exchangeRateApp.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mainPage : Xamarin.Forms.TabbedPage
    {

        public mainPage ()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}