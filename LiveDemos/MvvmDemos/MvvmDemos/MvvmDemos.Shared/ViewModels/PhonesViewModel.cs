using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

using MvvmDemos;
using System.Windows.Input;

namespace MvvmDemos.ViewModels
{
    public class PhonesViewModel : ViewModelBase, IPhonesViewModel
    {
        private ObservableCollection<PhoneViewModel> phones;

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                return this.phones;
            }
            set
            {
                //NO
                //this.phones = new ObservableCollection<PhoneViewModel>(value);

                //YES
                if (this.phones == null)
                {
                    this.phones = new ObservableCollection<PhoneViewModel>();
                }
                this.phones.Clear();
                this.phones.AddRange(value);
                this.SelectedPhone = this.phones.First();
            }
        }

        public PhoneViewModel NewPhone { get; set; }

        public PhoneViewModel SelectedPhone
        {
            get
            {
                return this.selectedPhone;
            }
            set
            {
                this.selectedPhone = value;
                this.OnPropertyChanged("SelectedPhone");
            }
        }

        #region Commands

        public ICommand SaveNewPhone
        {
            get
            {
                if (this.saveNewPhoneCommand == null)
                {
                    this.SaveNewPhone = new DelegateCommand(execute: this.PerformSaveNewPhone);
                }
                return this.saveNewPhoneCommand;
            }
            set
            {
                this.saveNewPhoneCommand = value;
            }
        }

        #endregion

        public PhonesViewModel()
        {
            this.Phones = new PhoneViewModel[]
            {
                new PhoneViewModel("Samsung", "Galaxy S"),
                new PhoneViewModel("Samsung", "Galaxy S2"),
                new PhoneViewModel("Samsung", "Galaxy S3"),
                new PhoneViewModel("Samsung", "Galaxy S4"),
                new PhoneViewModel("Samsung", "Galaxy S5")
            };
        }

        public void AddRandomPhone()
        {
            this.phones.Add(this.GetRandomPhone());
        }

        public void PerformSaveNewPhone()
        {
            var b = 5;
        }

        static Random rand = new Random();

        private PhoneViewModel selectedPhone;
        private ICommand saveNewPhoneCommand;

        private PhoneViewModel GetRandomPhone()
        {
            return new PhoneViewModel("Phone #" + rand.Next(),
                "Model #" + rand.Next());
        }
    }
}
