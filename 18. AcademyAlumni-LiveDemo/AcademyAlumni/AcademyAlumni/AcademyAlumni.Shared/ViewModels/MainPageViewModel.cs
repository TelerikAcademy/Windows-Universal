using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

using GalaSoft.MvvmLight;
using Parse;


using AcademyAlumni.Models;



namespace AcademyAlumni.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<EventViewModel> events;
        private bool initializing;

        public MainPageViewModel()
        {
            this.LoadEvents();
        }

        private async Task LoadEvents()
        {
            this.Initializing = true;

            //var cache = ParseConfig.CurrentConfig.Get<object>("cache");

            var user = UserViewModel.FromModel(ParseUser.CurrentUser);
            var events = await new ParseQuery<EventModel>()
                    .Where(ev => ev.Category.Initiative == Initiative.Any ||
                        user.Categories.Any(userCat => userCat.ObjectId == ev.Category.ObjectId))
                    .FindAsync();

            this.Events = events.AsQueryable()
                    .Select(EventViewModel.FromModel);

            this.Initializing = false;
        }

        public bool Initializing
        {
            get
            {
                return this.initializing;
            }
            set
            {
                this.initializing = value;
                this.RaisePropertyChanged(() => this.Initializing);
            }
        }

        public IEnumerable<EventViewModel> Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new ObservableCollection<EventViewModel>();
                }
                return this.events;
            }
            set
            {
                if (this.events == null)
                {
                    this.events = new ObservableCollection<EventViewModel>();
                }
                this.events.Clear();
                foreach (var item in value)
                {
                    this.events.Add(item);
                }
            }
        }
    }
}
