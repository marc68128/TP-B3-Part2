using System;
using System.Collections.Generic;
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
    public partial class BookDetails : PhoneApplicationPage
    {
        public BookDetails()
        {
            InitializeComponent();
            DataContext = new BookPageViewModel();
        }

        private BookPageViewModel ViewModel
        {
            get { return DataContext as BookPageViewModel; }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.OnNavigatedTo(NavigationContext, NavigationService);
            base.OnNavigatedTo(e);
        }
    }
}