using System;
using System.Collections.Generic;
using System.Text;

namespace MvvmDemos.ViewModels
{
    public interface IPhonesViewModel
    {
        IEnumerable<PhoneViewModel> Phones { get; set; }
    }
}
