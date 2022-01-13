using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Prodat.AppHelpers;
using Prodat.Models;
using Proddat.Services;
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
        IApiServices apiServices;
        public LoginPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IApiServices apiServices)
            : base(navigationService, pageDialogService)
        {
            this.apiServices = apiServices;
            LoginCommand = new Command(async () =>
            {
                OnLoginClicked();
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

            CheckRemeberUser();
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

        private bool mIsRemember;
        public bool IsRemember
        {
            get { return mIsRemember; }
            set
            {
                mIsRemember = value;
                if (!value)
                {
                    if (!string.IsNullOrEmpty(LoginId) && !string.IsNullOrEmpty(Password))
                    {
                        RemoveEasyLogin();
                    }
                }
                RaisePropertyChanged();
            }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand ResetPasswordCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        private async void OnLoginClicked()
        {
            try
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
                    this.IsBusy = true;
                    await Task.Delay(500);
                    var mainPage = Application.Current.MainPage;
                    var user = new UserModel()
                    {
                        device_type = AppConstants.DeviceType,
                        mac_id = AppConstants.MacID,
                        station_id = AppConstants.StationID,
                        username = this.LoginId,
                        password = this.Password
                    };
                    var userData = await apiServices.LoginAsync(user);
                    if (userData != null && !string.IsNullOrEmpty(userData.error))
                    {
                        await PageDialogService.DisplayAlertAsync("Login failed!", userData.error, "OK");
                        IsBusy = false;
                    }
                    else
                    {
                        var id = userData.station_list.FirstOrDefault().id;
                        KeyStorage.Set("token", userData.token);
                        KeyStorage.Set("firstName", userData.first_name);
                        KeyStorage.Set("ID", Convert.ToString(id));

                        await SetEasyLogin();

                        getApiCalls();
                        IsBusy = false;
                        await NavigationService.NavigateAsync("../BarcodeScanPage");

                        //remove login after success login
                        // var lastPage = (mainPage as NavigationPage).RootPage;
                        // mainPage.Navigation.RemovePage(lastPage);
                    }
                }
            }
            catch (Exception ex)
            {
                PageDialogService.DisplayAlertAsync("Error", ex.Message, "OK");
                IsBusy = false;
            }
        }

        #region GetAPiCalls
        public async void getApiCalls()
        {
            //get all stations
            var stations = await apiServices.GetAllStationsRawAsync();
        }
        #endregion

        #region Easy Login Module
        public async void CheckRemeberUser()
        {
            var user_key = KeyStorage.Get("remember");
            if (!string.IsNullOrEmpty(user_key) && user_key.Equals("yes"))
            {
                LoginId = KeyStorage.Get("userName");
                Password = KeyStorage.Get("password");
                IsRemember = true;
            }
        }
        private async Task SetEasyLogin()
        {
            if (IsRemember)
            {
                KeyStorage.Set("userName", LoginId);
                KeyStorage.Set("password", Password);
                KeyStorage.Set("remember", "yes");
            }
            else
            {
                KeyStorage.Remove("userName");
                KeyStorage.Remove("password");
                KeyStorage.Remove("remember");
            }
        }
        private static void RemoveEasyLogin()
        {
            KeyStorage.Remove("userName");
            KeyStorage.Remove("password");
            KeyStorage.Remove("remember");
        }
        #endregion
    }
}
