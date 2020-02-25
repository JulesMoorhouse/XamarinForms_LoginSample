using System;
using System.Collections.Generic;
using LoginSample.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColour;
            lblUsername.TextColor = Constants.MainTextColour;
            lblPassword.TextColor = Constants.MainTextColour;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => btnSignin_Clicked(s, e);
        }

        void btnSignin_Clicked(System.Object sender, System.EventArgs e)
        {
            var user = new User(entryUsername.Text, entryPassword.Text);
            if (user.CheckInformation())
            {
                App.UserDatabase.SaveUser(user);
                DisplayAlert("Login", "Login success", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login was unsuccessfull, please check your username and password.", "OK");
            }
        }

    }
}
