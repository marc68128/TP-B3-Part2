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
using DemoLauncherChooser.Resources;
using Microsoft.Phone.Tasks;

namespace DemoLauncherChooser
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

          
        }


        public void AddContactClick(object sender, RoutedEventArgs routedEventArgs)
        {
            SaveContactTask task = new SaveContactTask();
            task.FirstName = "Marc";
            task.LastName = "Unterseh";
            task.MobilePhone = "0631174552";
            task.PersonalEmail = "148278@supinfo.com"; 

            task.Completed += TaskOnCompleted;

            task.Show();
        }

        private void TaskOnCompleted(object sender, SaveContactResult saveContactResult)
        {
            if (saveContactResult.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("Le contact a bien été ajouté !");
            }
            else
            {
                MessageBox.Show("Erreur !!!");
            }
        }


        public void ItineraryClick(object sender, RoutedEventArgs routedEventArgs)
        {
            MapsDirectionsTask task = new MapsDirectionsTask();
            task.End = new LabeledMapLocation("Point 1", new GeoCoordinate(15.120,7.123));
            task.Start = new LabeledMapLocation("Point 2", new GeoCoordinate(14.120, 7.6));
            task.Show();
        }
    }
}