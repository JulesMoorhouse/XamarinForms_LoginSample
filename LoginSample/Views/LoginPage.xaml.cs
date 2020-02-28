using System;
using System.Collections.Generic;
using LoginSample.Models;
using LoginSample.Views.Menu;
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
            App.StartCheckIfInternet(lblNoInternet, this);

            entryUsername.Completed += (s, e) => entryPassword.Focus();
            entryPassword.Completed += (s, e) => btnSignin_Clicked(s, e);
        }

        async void btnSignin_Clicked(System.Object sender, System.EventArgs e)
        {
            var user = new User(entryUsername.Text, entryPassword.Text);
            if (user.CheckInformation())
            {
                _ = DisplayAlert("Login", "Login success", "OK");
                //var result = await App.RestService.Login(user);
                var result = new Token(); // Dummy token as we don't have a website
                //if (result.AccessToken != null)
                if (result != null)
                {
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);

                    if (Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new NavigationPage(new Dashboard());
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                        await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));

                    }
                }
            }
            else
            {
                _ = DisplayAlert("Login", "Login was unsuccessfull, please check your username and password.", "OK");
            }
        }

    }
}
