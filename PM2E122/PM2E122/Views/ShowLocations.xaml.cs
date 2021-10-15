using System;
using PM2E122.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowLocations : ContentPage
    {
        private Localizacion locationTemporal = new Localizacion();
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

        private async void btnDeleteLocation_Clicked(object sender, EventArgs e)
        {
            var locationObtained = await App.BaseDatos.getLocationByCode(locationTemporal.id);
            if(locationObtained != null)
            {
                await App.BaseDatos.deleteLocation(locationObtained);

                await DisplayAlert("Eliminacion", "El registro se elimino correctamente", "OK");

                btnDeleteLocation.IsVisible = false;
                btnShowMap.IsVisible = false;
                chargeData();
            }
        }

        private async void btnShowMap_Clicked(object sender, EventArgs e)
        {
            var mapPage = new Map();
            /* 
            mapPage.BindingContext = locationTemporal;
            btnDeleteLocation.IsVisible = false;
            btnShowMap.IsVisible = false;
            */

            await Navigation.PushAsync(mapPage);
            
        }

        private async void listLocations_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Localizacion)e.SelectedItem;
            btnShowMap.IsVisible = true;
            btnDeleteLocation.IsVisible = true;

            if(itemSelected.id != 0)
            {
                var locationObtained = await App.BaseDatos.getLocationByCode(itemSelected.id);
                if(locationObtained != null)
                {
                    locationTemporal.id = locationObtained.id;
                    locationTemporal.latitude = locationObtained.latitude;
                    locationTemporal.length = locationObtained.length;
                    locationTemporal.longDescription = locationObtained.longDescription;
                    locationTemporal.shortDescription = locationObtained.shortDescription;
                }
            }
        }
    }
}