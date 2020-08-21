using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void CheckBox_CheckedChanged(System.Object sender, Xamarin.Forms.CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                try
                {
                    await SecureStorage.SetAsync("IsRememberLogin", "true");
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
            }
            else
            {
                try
                {
                    await SecureStorage.SetAsync("IsRememberLogin", "false");
                }
                catch (Exception ex)
                {
                    // Possible that device doesn't support secure storage on device.
                }
            }
        } 
    }
}
