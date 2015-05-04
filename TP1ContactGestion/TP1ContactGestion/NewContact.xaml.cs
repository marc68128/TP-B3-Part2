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

namespace TP1ContactGestion
{
    public partial class NewContact : PhoneApplicationPage
    {
        public NewContact()
        {
            InitializeComponent();
        }

        private void SaveContact(object sender, EventArgs e)
        {
            var contact = new Contact();
            contact.LastName = LastName.Text;
            contact.FirstName = FirstName.Text;
            contact.BirthDate = BirthDate.Value; 

            using (var context = new ContactContext(ContactContext.DbConnectionString))
            {
                context.Contacts.InsertOnSubmit(contact);
                context.SubmitChanges();
            }

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}