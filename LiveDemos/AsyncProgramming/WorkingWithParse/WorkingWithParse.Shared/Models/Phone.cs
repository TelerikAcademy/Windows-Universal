using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace WorkingWithParse.Models
{
    [ParseClassName("Phones")]
    public class Phone : ParseObject
    {
        [ParseFieldName("vendor")]
        public string Vendor
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }

        [ParseFieldName("model")]
        public string Model
        {
            get { return GetProperty<string>(); }
            set { SetProperty<string>(value); }
        }
    }
}
