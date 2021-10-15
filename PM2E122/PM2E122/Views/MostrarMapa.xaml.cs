using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace PM2E122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarMapa : ContentPage
    {
        public MostrarMapa()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var pin = new Pin()
            {
                Position = new Position(37, -122),
                Label = "Some Pin!"
            };

            map.Pins.Add(pin);

            var span = MapSpan.FromCenterAndRadius(new Position(37, -122), Distance.FromMiles(10));
            map.MoveToRegion(span);
        }
    }
}