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
    public partial class EditContact : PhoneApplicationPage
    {
        public Contact Contact { get; set; }

        public EditContact()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string id = "";

            if (NavigationContext.QueryString.TryGetValue("contactId", out id))
            {
                using (var context = new ContactContext(ContactContext.DbConnectionString))
                {
                    Contact = context.Contacts.FirstOrDefault(c => c.Id == int.Parse(id));
                }
                if (Contact == null)
                {
                    throw new ArgumentException();
                }
                if (string.IsNullOrEmpty(FirstName.Text) && string.IsNullOrEmpty(LastName.Text))
                {
                    FirstName.Text = Contact.FirstName;
                    LastName.Text = Contact.LastName;
                    BirthDate.Value = Contact.BirthDate;
                }

            }

            base.OnNavigatedTo(e);
        }

        private void SaveContact(object sender, EventArgs e)
        {
            using (var context = new ContactContext(ContactContext.DbConnectionString))
            {
                var contact = context.Contacts.FirstOrDefault(c => c.Id == Contact.Id);
                contact.FirstName = FirstName.Text;
                contact.LastName = LastName.Text;
                contact.BirthDate = BirthDate.Value;
                context.SubmitChanges();
            }
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}