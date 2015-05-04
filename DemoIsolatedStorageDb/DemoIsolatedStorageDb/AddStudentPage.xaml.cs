using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using DemoIsolatedStorageDb.Model;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace DemoIsolatedStorageDb
{
    public partial class AddStudentPage : PhoneApplicationPage
    {
        public AddStudentPage()
        {
            InitializeComponent();
        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            var student = new Student();
            student.FirstName = FirstNameTb.Text;
            student.LastName = LastNameTb.Text;

            using (var context = new SchoolContext(SchoolContext.DBConnectionString))
            {
               context.Students.InsertOnSubmit(student);
               context.SubmitChanges();
            }

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}