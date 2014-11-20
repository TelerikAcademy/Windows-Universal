using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmDemos.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
            :this(new PhonesViewModel())
        {
        }

        public MainPageViewModel(IPhonesViewModel phonesVM)
        {
            this.PhonesVM = phonesVM;
        }

        public IPhonesViewModel PhonesVM { get; set; }
    }
}
