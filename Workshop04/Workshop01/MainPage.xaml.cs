using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Workshop01.Resources;
using Workshop01.ViewModels;

namespace Workshop01
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        private MainPageViewModel ViewModel
        {
            get { return DataContext as MainPageViewModel;}
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.OnNavigatedTo(NavigationContext, NavigationService);

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            ViewModel.GoToAddBookPage();
        }

        private void Books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox.SelectedIndex != -1)
            {
                var book = ViewModel.BookViewModels[ListBox.SelectedIndex];
                ViewModel.GoToBookDetailPage(book);         
            }
            
        }
    }
}