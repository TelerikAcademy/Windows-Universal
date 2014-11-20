using AcademyAlumni.Models;
using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;

namespace AcademyAlumni.ViewModels
{
    public class UserDetailsPageViewModel : ViewModelBase
    {
        private UserViewModel user;
        public UserDetailsPageViewModel()
        {
            this.LoadUser();

        }

        private async void LoadUser()
        {

            var userModel = ParseUser.CurrentUser;
            this.User = UserViewModel.FromModel(userModel);
            var categories = this.User.Categories.ToList();
            var cats = categories.Select(cat => new ParseQuery<CategoryModel>()
                    .GetAsync(cat.ObjectId).Result).ToList();
            var b = 5;
        }


        public UserViewModel User
        {
            get
            {
                return this.user;
            }
            set
            {
                this.user = value;
                this.RaisePropertyChanged(() => this.User);
            }
        }
    }
}
