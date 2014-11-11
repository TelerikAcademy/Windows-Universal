using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueConversion.Common;

namespace DataContext.ViewModels
{
    public class Person //: BaseVM
    {
        //private int age;
        //private string name;

        //public string Name
        //{
        //    get
        //    {
        //        return this.name;
        //    }
        //    set
        //    {
        //        if (this.name == value) return;
        //        this.name = value;
        //        NotifyPropertyChanged("Name");
        //    }
        //}

        //public int Age
        //{
        //    get
        //    {
        //        return this.age;
        //    }
        //    set
        //    {
        //        if (this.age == value) return;
        //        this.age = value;
        //        NotifyPropertyChanged("Age");
        //    }
        //}

        public string Name { get; set; }

        public int Age { get; set; }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person()
            : this("", 0)
        { }
    }
}
