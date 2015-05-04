using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using TP1ContactGestion.Model;
using TP1ContactGestion.Resources;

namespace TP1ContactGestion
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<Contact> Contacts { get; set; }
        public MainPage()
        {
            InitializeComponent();

            using (var context = new ContactContext(ContactContext.DbConnectionString))
            {
                Contacts = context.Contacts.ToList();
            }

            ListBox.ItemsSource = Contacts;
        }


        private void AddContact(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewContact.xaml", UriKind.Relative));
        }

        private void NewContactSelected(object sender, SelectionChangedEventArgs e)
        {
            var contact = Contacts[ListBox.SelectedIndex];
            NavigationService.Navigate(new Uri("/EditContact.xaml?contactId=" + contact.Id, UriKind.Relative));
        }
    }
}