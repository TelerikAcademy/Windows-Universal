using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows.Input;
using AttachedProperties.Commands;

namespace AttachedProperties.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private PhoneViewModel selectedPhone;
        private int phoneIndex;
        private PhoneViewModel[] phones;
        private ICommand prevCommand;
        private ICommand nextCommand;

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

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                return this.phones;
            }
            set
            {
                this.phones = value.ToArray();
                this.SelectedPhone = this.phones[0];
                this.phoneIndex = 0;
            }
        }

        public ICommand Prev
        {
            get
            {
                if (this.prevCommand == null)
                {
                    this.prevCommand = new DelegateCommand(this.GoToPrevPhone);
                }

                return this.prevCommand;
            }
        }

        public ICommand Next
        {
            get
            {
                if (this.nextCommand == null)
                {
                    this.nextCommand = new DelegateCommand(this.GoToNextPhone);
                }
                return this.nextCommand;
            }
        }

        public void GoToPrevPhone()
        {
            var index = phoneIndex - 1;
            if (index < 0)
            {
                return;
            }
            this.phoneIndex = index;
            this.SelectedPhone = this.phones[this.phoneIndex];
        }

        public void GoToNextPhone()
        {
            var index = phoneIndex + 1;
            if (this.phones.Length <= index)
            {
                return;
            }
            this.phoneIndex = index;
            this.SelectedPhone = this.phones[this.phoneIndex];
        }
    }
}
