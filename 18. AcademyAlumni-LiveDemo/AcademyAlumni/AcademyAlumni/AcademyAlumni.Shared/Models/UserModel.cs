using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcademyAlumni.Models
{
    public class UserModel : ParseUser
    {
        [ParseFieldName("eventsCreated")]
        public IEnumerable<EventModel> EventsCreated
        {
            get { return GetProperty<IEnumerable<EventModel>>(); }
            set { SetProperty<IEnumerable<EventModel>>(value); }
        }

        [ParseFieldName("eventsJoined")]
        public IEnumerable<EventModel> EventsJoined 
        {
            get { return GetProperty<IEnumerable<EventModel>>(); }
            set { SetProperty<IEnumerable<EventModel>>(value); }
        }

        [ParseFieldName("categories")]
        public IEnumerable<CategoryModel> Categories
        {
            get { return GetProperty<IEnumerable<CategoryModel>>(); }
            set { SetProperty<IEnumerable<CategoryModel>>(value); }
        }
    }
}
