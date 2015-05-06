using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Phone.Tasks;
using Workshop01.Model;
using Workshop01.Services;

namespace Workshop01.ViewModels
{
    public class AddBookViewModel : PageViewModelBase
    {
        private BookService _bookService;
        private IsolatedStorageService _isolatedStorageService;
        private PhotoResult _lastChoosenPicture;
        public AddBookViewModel()
        {
            _bookService = new BookService();
            _isolatedStorageService = new IsolatedStorageService();
        }

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
            base.OnNavigatedTo(navigationContext, navigationService);
            if (BookViewModel == null)
                BookViewModel = new BookViewModel();

            if (!App.IsAppInstancePreserved)
            {
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
                if (settings.Contains("lastBook"))
                {
                    BookViewModel = new BookViewModel(settings["lastBook"] as Book);
                    settings.Remove("lastBook");
                    settings.Save();
                }
            }

        }

        public override void OnNavigatingFrom()
        {
            base.OnNavigatingFrom();
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains("lastBook"))
            {
                settings.Add("lastBook", BookViewModel.GetBook());
            }
            else
            {
                settings["lastBook"] = BookViewModel.GetBook();
            }
            settings.Save();
        }

        public override void OnBackKeyPress()
        {
            var result = MessageBox.Show("Attention", "Etes vous sur de vouloir annuler la saisi ?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                base.OnBackKeyPress();
            }
        }

        public void AddPicture()
        {
            PhotoChooserTask task = new PhotoChooserTask();
            task.Completed += PhotoTaskOnCompleted;
            task.Show();
        }

        private void PhotoTaskOnCompleted(object sender, PhotoResult photoResult)
        {
            if (photoResult.TaskResult != TaskResult.Cancel)
            {
                _lastChoosenPicture = photoResult;
                var bitmapImage = new BitmapImage();
                bitmapImage.SetSource(photoResult.ChosenPhoto);
                BookViewModel.Picture = bitmapImage;
            }
        }

        public void Save()
        {
            var id = _bookService.AddBook(BookViewModel.GetBook());
            if (_lastChoosenPicture != null)
                _isolatedStorageService.SaveImage(_lastChoosenPicture.ChosenPhoto, id, _lastChoosenPicture.OriginalFileName);
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        public void Cancel()
        {
            NavigationService.GoBack();
        }
    }
}
