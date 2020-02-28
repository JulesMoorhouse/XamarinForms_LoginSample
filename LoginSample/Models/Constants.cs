using System;
using Xamarin.Forms;

namespace LoginSample.Models
{
    public class Constants
    {
        public static bool IsDev = true;

        public static Color BackgroundColour = Color.FromRgb(58, 152, 215);
        public static Color MainTextColour = Color.White;


        public static int LoginIconHeight = 120;

        //------ Login ------
        public static string LoginUrl = "https://test.com/api/Auth/Login";

        public static string NoInternetText = "No Internet, please reconnect.";
    }
}
