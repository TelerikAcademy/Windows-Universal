using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvvmDemos.ViewModels
{
    public class PhoneViewModel
    {
        public string Vendor { get; set; }
        public string Model { get; set; }

        public PhoneViewModel(string vendor, string model)
        {
            this.Vendor = vendor;
            this.Model = model;
        }
    }
}
