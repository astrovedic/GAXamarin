using Plugin.GAXamarin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GADemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            CrossGAXamarin.Current.TrackUser("AReyes27");

            CrossGAXamarin.Current.TrackScreen("Main Screen", 1, "Mobility Solutions");

            CrossGAXamarin.Current.TrackEvent("Screen Lifecycle", "OnAppearing", "AppEvent", 1, "Mobility Solutions");

            await Task.Delay(1000);

            CrossGAXamarin.Current.TrackTime("Backend", "GetMaps", 1000);

            CrossGAXamarin.Current.TrackException("Server is not reachable", false);
        }
    }
}
