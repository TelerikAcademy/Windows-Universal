using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenu.ViewModels
{
    public class PhonesViewModel
    {
        private ObservableCollection<PhoneViewModel> phones;

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                if (this.phones == null)
                {
                    this.Phones = this.GetGeneratedPhones();
                }
                return this.phones;
            }
            set
            {
                if (this.phones != value)
                {
                    if (this.phones == null)
                    {
                        this.phones = new ObservableCollection<PhoneViewModel>();
                    }
                    this.phones.Clear();
                    foreach (var item in value)
                    {
                        this.phones.Add(item);
                    }
                }
            }
        }

        public PhonesViewModel()
        {
        }

        private IEnumerable<PhoneViewModel> GetGeneratedPhones()
        {
            PhoneViewModel[] phones =
            {
                new PhoneViewModel()
                {
                    Vendor = "Samsung",
                    Model = "Galaxy S4",
                },
                new PhoneViewModel()
                {
                    Vendor = "Apple",
                    Model = "iPhone 4",
                },
                new PhoneViewModel()
                {
                    Vendor = "HTC",
                    Model = "One",
                },
                new PhoneViewModel()
                {
                    Vendor = "Nokia",
                    Model = "Lumia 920",
                },
            };

            return phones;
        }
    }
}
