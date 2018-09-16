using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using static MyTasks.TODO.App;

namespace MyTasks.TODO.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel : FreshBasePageModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Title => "Login";

        public Command LoginCommand => new Command(Login);

        public LoginViewModel()
        {
        }

        private void Login()
        {
            if (Username == "nav" && Password == "pass")
                CoreMethods.SwitchOutRootNavigation(NavigationStacks.MainNavStack);
            else
                CoreMethods.DisplayAlert("Login", "Invalid username or password", "Okay");
        }

    }
}
