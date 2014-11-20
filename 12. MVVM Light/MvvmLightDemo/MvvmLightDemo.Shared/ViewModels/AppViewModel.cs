using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLightDemo.ViewModels
{
    public class AppViewModel : ViewModelBase
    {
        private string displayName;
        public AppViewModel()
        {
            this.LoadData();

            //
        }

        private async Task LoadData()
        {
            //this.DisplayName = await HttpRequester.Instance.GetDisplayName();
            //var items = await this.GetEnumerable();
        }

        //private async Task<IEnumerable<string>> GetEnumerable()
        //{
        //    //return this.GetItemsOverHttp();
        //}

        public string DisplayName
        {
            get
            {
                return this.displayName;
            }
            set
            {
                this.displayName = value;
                this.RaisePropertyChanged(() => this.DisplayName);

            }
        }
    }
}
