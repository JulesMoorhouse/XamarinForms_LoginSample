using System;
using System.Collections.Generic;
using LoginSample.Models;
using LoginSample.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginSample.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColour;
            App.StartCheckIfInternet(lblNoInternet, this);
        }

        async void Screen1_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new InfoScreen1());
        }
    }
}
