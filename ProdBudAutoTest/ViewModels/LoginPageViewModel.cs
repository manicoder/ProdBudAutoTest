using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            LoginCommand = new Command(async () =>
            {
                if (this.IsUserRemeber)
                {
                    try
                    {
                        await SecureStorage.SetAsync("logingId", this.LoginId);
                        await SecureStorage.SetAsync("pwd", this.Password);

                        
                    }
                    catch (Exception ex)
                    {
                        // Possible that device doesn't support secure storage on device.
                    }
                }
                NavigationService.NavigateAsync("../BarcodeScanPage");
            });
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            var isChecked = await SecureStorage.GetAsync("IsRememberLogin");
            if (isChecked == "true")
            {
                IsUserRemeber = true;
                this.LoginId = await SecureStorage.GetAsync("logingId");
                this.Password = await SecureStorage.GetAsync("pwd");
            }
        }
        private string mLoginId;
        public string LoginId
        {
            get { return mLoginId; }
            set
            {
                mLoginId = value;
                RaisePropertyChanged();
            }
        }

        private string mPassword;
        public string Password
        {
            get { return mPassword; }
            set
            {
                mPassword = value;
                RaisePropertyChanged();
            }
        }
        private bool mIsUserRemeber;
        public bool IsUserRemeber
        {
            get { return mIsUserRemeber; }
            set
            {
                mIsUserRemeber = value;
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
    }
}
