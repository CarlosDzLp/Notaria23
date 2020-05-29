using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace Notaria23.Views.Principal
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(0, 0), Distance.FromMeters(500)));
            GenerateAPin();
        }
        private async void GenerateAPin()
        {
            try
            {
                var response = await Helpers.Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Location);
                if (response)
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                    var location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        var pin = new Pin
                        {
                            Type = PinType.Place,
                            Label = "Aqui estas!!",
                            Position = new Position(location.Latitude, location.Longitude),

                        };
                        map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(500)));
                        //pin.Icon= BitmapDescriptorFactory.FromBundle("");
                        map.Pins.Add(pin);
                    }
                }
            }
            catch (Exception ex)
            {
                try
                {
                    var location = await Geolocation.GetLastKnownLocationAsync();
                    if (location != null)
                    {
                        if (location != null)
                        {
                            var pin = new Pin
                            {
                                Type = PinType.Place,
                                Label = "Aqui estas!!",
                                Position = new Position(location.Latitude, location.Longitude)
                            };
                            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(500)));
                            map.Pins.Add(pin);
                        }
                    }
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
