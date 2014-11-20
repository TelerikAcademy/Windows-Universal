using AcademyAlumni.Common;
using GalaSoft.MvvmLight;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AcademyAlumni.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public UserViewModel User { get; set; }

        public event EventHandler LoginSuccessfull;

        public LoginPageViewModel()
        {
            this.User = new UserViewModel()
            {
                Username = "Doncho",
                Password = "123456q"
            };
        }

        public async Task<bool> Login()
        {
            try
            {
                await ParseUser.LogInAsync(this.User.Username, this.User.Password);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
