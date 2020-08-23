using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
            : base(navigationService, pageDialogService)
        {
            LoginCommand = new Command(async () =>
            {
                if (string.IsNullOrEmpty(LoginId))
                {
                    await PageDialogService.DisplayAlertAsync("Required", "Please enter Login ID", "OK");
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    await PageDialogService.DisplayAlertAsync("Required", "Please enter Password", "OK");
                }
                else
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
                }
            });

            ResetPasswordCommand = new Command(() =>
            {
                PageDialogService.DisplayAlertAsync("Reset Password", "Pleasse conatct administrator  for reset your password", "OK");
            });

            RegisterCommand = new Command(() =>
            {
                PageDialogService.DisplayAlertAsync("Registration", "Pleasse conatct administrator  for reset your password", "OK");
            });
        }
        public async Task<PermissionStatus> CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            // Additionally could prompt the user to turn on in settings

            return status;
        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await CheckAndRequestLocationPermission();

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
        public ICommand ResetPasswordCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

    }
}
