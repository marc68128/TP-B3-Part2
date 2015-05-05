using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace DemoMVVM.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private string myString; 
        public string MyString
        {
            get { return myString; }
            set
            {
                myString = value;
                OnPropertyChanged();
            }
        }

        public MainPageViewModel()
        {
            MyString = "Salut";

            Observable.Interval(new TimeSpan(0, 0, 0, 2)).ObserveOn(RxApp.MainThreadScheduler).Subscribe(t =>
            {
                MyString = "Salut " + t.ToString();
            });
        }
        
    }
}
