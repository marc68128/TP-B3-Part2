using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;

namespace DemoCommand.ViewModels
{
    class MainPageViewModel : ReactiveObject
    {
        private int myNum;
        public int MyNum
        {
            get { return myNum; }
            set { this.RaiseAndSetIfChanged(ref myNum, value); }
        }


        public ReactiveCommand<object> AddOneCommand { get; private set; }

        public MainPageViewModel()
        {
            AddOneCommand = ReactiveCommand.Create();
            AddOneCommand.Subscribe(_ =>
            {
                MyNum = MyNum + 1;
            });
        }
    }
}
