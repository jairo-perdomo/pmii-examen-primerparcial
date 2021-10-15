using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowLocations : ContentPage
    {
        public ShowLocations()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            chargeData();
        }

        private async void chargeData()
        {
            var listViewLocations = await App.BaseDatos.getListLocations();

            if(listViewLocations != null)
            {
                listLocations.ItemsSource = listViewLocations;
            }
        }

        private void btnDeleteLocation_Clicked(object sender, EventArgs e)
        {

        }

        private void btnShowMap_Clicked(object sender, EventArgs e)
        {

        }
    }
}