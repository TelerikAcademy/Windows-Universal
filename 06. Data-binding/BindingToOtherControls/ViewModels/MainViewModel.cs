using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingToOtherControls.ViewModels
{
    public class MainViewModel
    {
        public Person Person { get; set; }

        public MainViewModel()
        {
            this.Person = new Person("Ivan", 23);
        }
    }
}
