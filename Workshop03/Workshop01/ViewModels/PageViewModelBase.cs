using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Workshop01.ViewModels
{
    public class PageViewModelBase : ViewModelBase
    {
        protected NavigationContext NavigationContext;
        protected NavigationService NavigationService;

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        private string _busyMessage;
        public string BusyMessage
        {
            get { return _busyMessage; }
            set
            {
                _busyMessage = value;
                RaisePropertyChanged();
            }
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext, NavigationService navigationService)
        {
            NavigationContext = navigationContext;
            NavigationService = navigationService; 
        }

        public virtual void OnNavigatingFrom()
        {
            
        }

        public virtual void OnBackKeyPress()
        {
            
        }

        public virtual void OnLoaded()
        {
            
        }


    }
}
