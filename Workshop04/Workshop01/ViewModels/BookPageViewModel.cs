using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using Microsoft.Phone.Shell;
using Workshop01.Model;

namespace Workshop01.ViewModels
{
    public class BookPageViewModel : PageViewModelBase
    {
        private BookViewModel _bookViewModel;
        public BookViewModel BookViewModel
        {
            get { return _bookViewModel; }
            set
            {
                _bookViewModel = value;
                RaisePropertyChanged();
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext, NavigationService navigationService)
        {
            string bookId;
            if (navigationContext.QueryString.TryGetValue("bookId", out bookId))
            {
                using (var context = new BookDataContext(BookDataContext.DbConnectionString))
                {
                    var book = context.Books.FirstOrDefault(b => b.Id == int.Parse(bookId));
                    if (book != null)
                    {
                        BookViewModel = new BookViewModel(book);
                    }
                }

            }
            base.OnNavigatedTo(navigationContext, navigationService);
        }

        public void Pin()
        {
            var myTile = ShellTile.ActiveTiles.FirstOrDefault(
                t => t.NavigationUri.OriginalString.Contains("/Views/BookDetails.xaml?bookId=" + BookViewModel.Id));

            if (myTile == null)
            {
                ShellTile.Create(new Uri("/Views/BookDetails.xaml?bookId=" + BookViewModel.Id, UriKind.Relative), new StandardTileData
                {
                    Title = BookViewModel.Title,
                    BackTitle = BookViewModel.Title,
                    BackContent = BookViewModel.Author
                });
            }
        }
    }
}
