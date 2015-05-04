using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DemoIsolatedStorage.Resources;

namespace DemoIsolatedStorage
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            string text = "";
            if (settings.TryGetValue("key", out text))
            {
                TextBox.Text = text;
            }
            
        }


        private void SaveData(object sender, RoutedEventArgs e)
        {
            var text = TextBox.Text;
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("key"))
            {
                settings["key"] = text;
            }
            else
            {
                settings.Add("key", text);
            }            
            settings.Save();
        }
    }
}