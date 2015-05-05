using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Workshop01.ViewModels;

namespace Workshop01.Views
{
    public partial class AddBook : PhoneApplicationPage
    {
        public AddBook()
        {
            InitializeComponent();
            DataContext = new AddBookViewModel();
        }

        private AddBookViewModel ViewModel
        {
            get { return DataContext as AddBookViewModel;}
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.OnNavigatedTo(NavigationContext, NavigationService);
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            ViewModel.OnBackKeyPress();
        }

        public void AddPicture(object sender, RoutedEventArgs routedEventArgs)
        {
            ViewModel.AddPicture();
        }

        public void SaveBookClick(object sender, EventArgs eventArgs)
        {
            ViewModel.Save();
        }

        public void CancelClick(object sender, EventArgs eventArgs)
        {
            ViewModel.Cancel();
        }
    }
}