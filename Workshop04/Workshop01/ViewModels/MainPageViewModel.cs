using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Workshop01.Services;

namespace Workshop01.ViewModels
{
    public class MainPageViewModel : PageViewModelBase
    {
        private BookService _bookService;

        public MainPageViewModel()
        {
            _bookService = new BookService();
            BookViewModels = new ObservableCollection<BookViewModel>();
        }

        private ObservableCollection<BookViewModel> _bookViewModels;
        public ObservableCollection<BookViewModel> BookViewModels
        {
            get { return _bookViewModels; }
            set
            {
                _bookViewModels = value;
                RaisePropertyChanged();
            }
        }


        private Visibility  _listBoxVisibility;
        public Visibility ListBoxVisibility
        {
            get { return _listBoxVisibility; }
            set
            {
                _listBoxVisibility = value;
                RaisePropertyChanged();
            }
        }

        private Visibility _noItemTextVisibility;
        public Visibility NoItemTextVisibility
        {
            get { return _noItemTextVisibility; }
            set
            {
                _noItemTextVisibility = value;
                RaisePropertyChanged();
            }
        }

        public void GoToAddBookPage()
        {
            NavigationService.Navigate(new Uri("/Views/AddBook.xaml", UriKind.Relative));
        }
        public void GoToBookDetailPage(BookViewModel book)
        {
            NavigationService.Navigate(new Uri("/Views/BookDetails.xaml?bookId=" + book.Id, UriKind.Relative));
        }

        public override void OnNavigatedTo(NavigationContext navigationContext, NavigationService navigationService)
        {
            RefreshBooks(); 
            base.OnNavigatedTo(navigationContext, navigationService);
        }

        public void RefreshBooks()
        {
            IsBusy = true;
            BusyMessage = "Chargement des livres"; 
            BookViewModels.Clear();
            _bookService.GetBooks().Select(b => new BookViewModel(b)).ToList().ForEach(vm => BookViewModels.Add(vm));

            if (BookViewModels.Count > 0 )
            {
                NoItemTextVisibility = Visibility.Collapsed;
                ListBoxVisibility = Visibility.Visible;
            }
            else
            {
                NoItemTextVisibility = Visibility.Visible;
                ListBoxVisibility = Visibility.Collapsed;
            }

            IsBusy = false; 
        }
    }
}
