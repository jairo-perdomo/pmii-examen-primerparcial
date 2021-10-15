using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace PM2E122.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLocation : ContentPage
    {
        private double numberLatitude;
        private double numberLength;

        public AddLocation()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Locate();
        }

        private async void getLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    txtLatitude.Text = location.Latitude.ToString();
                    txtLongitud.Text = location.Longitude.ToString();
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await DisplayAlert("Faild", fnsEx.Message, "OK");
            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Faild", pEx.Message, "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Faild", ex.Message, "OK");
            }
        }

        private async void Locate()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        txtLatitude.Text = loc.Latitude.ToString();
                        numberLatitude = double.Parse(txtLatitude.Text);
                        txtLongitud.Text = loc.Longitude.ToString();
                        numberLength = double.Parse(txtLongitud.Text);
                    };
                }
            }
        }

        private async Task<bool> validateForm()
        {
            if (String.IsNullOrWhiteSpace(txtLatitude.Text))
            {
                await DisplayAlert("Advertencia", "El campo de latitud esta vacio", "OK");
                return false;
            }
            else if(String.IsNullOrWhiteSpace(txtLongitud.Text))
            {
                await DisplayAlert("Advertencia", "El campo de longitud esta vacio", "OK");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txtLongDescription.Text))
            {
                await DisplayAlert("Advertencia", "El campo de Descripcion larga esta vacio", "OK");
                return false;
            }
            else if (String.IsNullOrWhiteSpace(txtShortDescription.Text))
            {
                await DisplayAlert("Advertencia", "El campo de descripcion corta esta vacio", "OK");
                return false;
            }

            return true;
        }

        private async void btnSaveLocation_Clicked(object sender, EventArgs e)
        {
            if(await validateForm())
            {
               
                var locationToSave = new Models.Localizacion()
                {
                    latitude = double.Parse(txtLatitude.Text),
                    length = double.Parse(txtLongitud.Text),
                    longDescription = txtLongDescription.Text,
                    shortDescription = txtShortDescription.Text
                };

                var resultforSave = await App.BaseDatos.saveLocation(locationToSave);
                if (resultforSave == 1)
                {
                    await DisplayAlert("Guardar", "Se ha guardado correctamente", "OK");

                }
                else
                {
                    await DisplayAlert("Error", "No se ha podido guardar", "OK");
                } 
            }

        }

        private void btnShowLocations_Clicked(object sender, EventArgs e)
        {

        }
    }

    
}