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
using DemoIsolatedStorageDb.Resources;

namespace DemoIsolatedStorageDb
{
    public partial class MainPage : PhoneApplicationPage
    {
        public List<Student> Students { get; set; }
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            using (var context = new SchoolContext(SchoolContext.DBConnectionString))
            {
                Students = context.Students.ToList(); 
            }

            ListBox.ItemsSource = Students;

        }

        private void AddStudent(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AddStudentPage.xaml", UriKind.Relative));
        }
    }
}