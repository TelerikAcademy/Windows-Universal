using AcademyAlumni.Models;
using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AcademyAlumni.ViewModels
{
    public class EventViewModel:ViewModelBase
    {
        private string title;
        public static Expression<Func<EventModel, EventViewModel>> FromModel
        {
            get
            {
                return model => new EventViewModel()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Creator = model.Creator,
                    EventDate = model.EventDate,
                    Category= model.Category
                };
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.RaisePropertyChanged(() => this.Title);
            }
        }

        public string Description { get; set; }

        public ParseUser Creator { get; set; }

        public DateTime EventDate { get; set; }

        public CategoryModel Category { get; set; }
    }
}
