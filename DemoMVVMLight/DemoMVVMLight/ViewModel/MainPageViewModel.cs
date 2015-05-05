using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace DemoMVVMLight.ViewModel
{
    public class MainPageViewModel : MainViewModel
    {
        public MainPageViewModel()
        {
            AddOneCommand = new RelayCommand(() =>
            {
                MyNum += 1;
            });
        }

        private int myNum;
        public int MyNum
        {
            get { return myNum; }
            set
            {
                myNum = value;
                this.RaisePropertyChanged();
            }
        }

        public ICommand AddOneCommand { get; set; }
        
    }
}
