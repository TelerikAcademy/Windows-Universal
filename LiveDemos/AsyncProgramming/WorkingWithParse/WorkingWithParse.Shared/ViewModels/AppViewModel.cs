using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using WorkingWithParse.Models;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Threading;

namespace WorkingWithParse.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private ObservableCollection<PhoneViewModel> phones;
        private ICommand refreshCommand;

        public IEnumerable<PhoneViewModel> Phones
        {
            get
            {
                if (this.phones == null)
                {
                    this.Phones = new ObservableCollection<PhoneViewModel>();
                }
                return this.phones;
            }
            set
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

        public ICommand Refresh
        {
            get
            {
                if (this.refreshCommand == null)
                {
                    this.refreshCommand = new RelayCommand(this.PerformRefresh);
                }
                return this.refreshCommand;
            }
        }

        private void PerformRefresh()
        {
            this.LoadPhones();
        }

        public AppViewModel()
        {
            this.LoadPhones();
        }

        public async Task LoadPhones()
        {
            //var phoneLinq = 
            //    from phone in new ParseQuery<Phone>()
            //    where phone.Model.StartsWith("L")
            //    orderby phone.Model
            //    select phone;

            var phones = await new ParseQuery<Phone>()
                .FindAsync(
                CancellationToken.None);

            this.Phones = phones.AsQueryable()
                .Select(PhoneViewModel.FromModel);
            //var phones = await ParseObject.GetQuery("Phones")
            //        .FindAsync();
            //this.Phones = phones.AsQueryable()
            //    .Select(PhoneViewModel.FromParseObject);
        }
    }
}
