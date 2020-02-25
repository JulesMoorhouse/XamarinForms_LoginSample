using System;

using Xamarin.Forms;

namespace LoginSample.Views
{
    public class Login : ContentPage
    {
        public Login()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

