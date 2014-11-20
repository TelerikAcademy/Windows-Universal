using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WorkingWithParse.Models;

namespace WorkingWithParse.ViewModels
{
    public class PhoneViewModel
    {
        public static Expression<Func<Phone, PhoneViewModel>> FromModel
        {
            get
            {
                return model =>
                    new PhoneViewModel()
                    {
                        Vendor = model.Vendor,
                        Model = model.Model
                    };
            }
        }

        public string Vendor { get; set; }
        public string Model { get; set; }
    }
}
