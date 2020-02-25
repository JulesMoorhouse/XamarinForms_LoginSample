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
        }

        void btnSignin_Clicked(System.Object sender, System.EventArgs e)
        {
            var user = new User(entryUsername.Text, entryPassword.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login success", "OK");
            }
            else
            {
                DisplayAlert("Login", "Login was unsuccessfull, please check your username and password.", "OK");
            }
        }

    }
}
