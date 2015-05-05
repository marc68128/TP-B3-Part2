using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Workshop01.Model;
using Workshop01.Services;

namespace Workshop01.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private IsolatedStorageService _isolatedStorageService;

        public BookViewModel()
        {
            _isolatedStorageService = new IsolatedStorageService();
        }

        public BookViewModel(Book b)
        {
            _isolatedStorageService = new IsolatedStorageService();
            Id = b.Id;
            Author = b.Author;
            Title = b.Title;
            LoadPicture();
        }

        public int Id { get; set; }

        private string _author;
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                RaisePropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged();
            }
        }

        private ImageSource _picture;
        public ImageSource Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                RaisePropertyChanged();
            }
        }

        public Book GetBook()
        {
            return new Book
            {
                Author = Author,
                Title = Title,
                Id = Id
            };
        }

        public void LoadPicture()
        {
           Picture = _isolatedStorageService.GetImage(Id);
        }

    }
}
