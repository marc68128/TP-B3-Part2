using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using DemoContact.Resources;
using Microsoft.Phone.UserData;

namespace DemoContact
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Contacts cons = new Contacts();
            cons.SearchCompleted += ConsOnSearchCompleted;
            cons.SearchAsync("Marc", FilterKind.DisplayName, "Contact Test");
        }

        private void ConsOnSearchCompleted(object sender, ContactsSearchEventArgs contactsSearchEventArgs)
        {
            var count = contactsSearchEventArgs.Results.Count();
            Contact c = contactsSearchEventArgs.Results.First();
        }
    }
}