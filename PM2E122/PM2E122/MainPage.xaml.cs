using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PM2E122.Views;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace PM2E122
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /* private async void Locate()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if(locator.IsGeolocationAvailable)
            {
                if(locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        latitud.Text = loc.Latitude.ToString();
                        numberLatitude = double.Parse(latitud.Text);
                        longitud.Text = loc.Longitude.ToString();
                        numberLength = double.Parse(longitud.Text);
                    };
                }
            }
        } */
        private async void btnAddLocation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLocation());
        }

        private async void btnListLocation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ShowLocations());
        }
    }
}
