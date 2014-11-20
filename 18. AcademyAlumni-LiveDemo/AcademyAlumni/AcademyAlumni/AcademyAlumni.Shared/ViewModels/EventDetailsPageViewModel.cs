using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyAlumni.ViewModels
{
    public class EventDetailsPageViewModel:ViewModelBase
    {
        private EventViewModel eventVM;
        public EventViewModel Event
        {
            get
            {
                return this.eventVM;
            }
            set
            {
                this.eventVM = value;
                this.RaisePropertyChanged(() => this.Event);
            }
        }
    }
}
