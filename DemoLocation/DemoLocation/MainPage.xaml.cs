using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DemoLocation.Resources;

namespace DemoLocation
{
    public partial class MainPage : PhoneApplicationPage
    {

        private GeoCoordinateWatcher _locator; 
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _locator = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            _locator.PositionChanged += LocatorOnPositionChanged;
            _locator.Start();
        }

        private void LocatorOnPositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                latTb.Text = e.Position.Location.Latitude.ToString();
                LngTb.Text = e.Position.Location.Longitude.ToString();
                AltitudeTb.Text = e.Position.Location.Altitude.ToString();
            });

        }
    }
}