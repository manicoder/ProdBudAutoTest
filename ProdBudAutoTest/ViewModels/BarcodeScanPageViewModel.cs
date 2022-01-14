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
    public class BarcodeScanPageViewModel : ViewModelBase
    {
        IApiServices _apiServices;
        public BarcodeScanPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IApiServices apiServices) : base(navigationService, pageDialogService)
        {
            _apiServices = apiServices;
            IsShowLogoutButton = false;
            PopupConfirmCommand = new Command((obj) =>
            {
                ConfirmManualPopup();
                if (obj is string param)
                {
                    if (param == "Confirm")
                    {
                        NavigationService.NavigateAsync("CheckOperationPage");
                    }
                    else
                    {
                        NavigationService.NavigateAsync("ManualSelectionPage");
                    }
                }
                //var showDialog = await this.PageDialogService.DisplayActionSheetAsync("Confirm if Model is related to VIN " + VinId + "\n Model: 123456", "Manual", "Confirm");
                //if (showDialog == "Confirm")
                //{
                //    NavigationService.NavigateAsync("CheckOperationPage");
                //}
                //else
                //{

                //}
            });
            ShowManualCommand = new Command((obj) =>
            {

                NavigationService.NavigateAsync("ManualSelectionPage");
            });
            LogoutCommand = new Command(() =>
            {
                KeyStorage.Remove("token");
                KeyStorage.Remove("firstName");
                FileSystemHelper.Instance.DeleteFile(AppConstants.ModelsFilename);
                FileSystemHelper.Instance.DeleteFile(AppConstants.StationsFileName);
                NavigationService.NavigateAsync("../LoginPage");
            });
            ToggleMenuCommand = new Command(() =>
            {
                if (IsShowLogoutButton)
                {
                    IsShowLogoutButton = false;
                }
                else
                {
                    IsShowLogoutButton = true;
                }
            });

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await CheckAndRequestLocationPermission();
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
            VinId = "";
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
        //       Prodat.Models.Sp_Process
        private Sp_Process mCurrentProcess;
        public Sp_Process CurrentProcess
        {
            get { return mCurrentProcess; }
            set
            {
                mCurrentProcess = value;
                RaisePropertyChanged();
            }
        }


        public async void GoToNextPgae()
        {
            IsBusy = true;
            try
            {
                await Task.Delay(500);
                var token = KeyStorage.Get("token");
                var vinResponse = await this._apiServices.GetVinNumberAsync(token, this.VinId);
                if (vinResponse != null && vinResponse.results != null && vinResponse.results.Count() > 0)
                {
                    var year = vinResponse.results.FirstOrDefault().model_year;
                    if (!string.IsNullOrEmpty(Convert.ToString(year)))
                    {
                        KeyStorage.Set("year", Convert.ToString(year));
                        var id = KeyStorage.Get("ID");
                        var allStations = await this._apiServices.GetStationDataAsync();
                        foreach (var item in allStations.results)
                        {
                            if (item.id == Convert.ToInt32(id))
                            {
                                foreach (var pro in item.process.sp_process)
                                {
                                    if (pro.year == Convert.ToInt32(year))
                                    {
                                        Services.CurrentProcess.Instance.Proccess = pro;
                                        ConfirmManualPopup();
                                        break;
                                    }
                                }
                            }

                        }
                        /*
                          for i in self.process_data:
                    if str(i["id"]) == str(self.station_id):
                        for j in i["process"]["sp_process"]:
                            if str(j["year"]) == str(self.year_id):
                                self.station_process = j['station_process']
                                self.isStationProcessSuccess = True
                                print("got process data")
                         */
                    }
                }
                else
                {
                    IsBusy = false;
                    PageDialogService.DisplayAlertAsync("Error", "Not Found", "OK");
                    return;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                PageDialogService.DisplayAlertAsync("Error", ex.Message, "OK");
                return;
            }
            IsBusy = false;
           

        }

        private void ConfirmManualPopup()
        {
            if (IsConfirmPopupVisible)
            {
                IsConfirmPopupVisible = false;
            }
            else
            {
                IsConfirmPopupVisible = true;
            }
        }

        private string mVinId;
        public string VinId
        {
            get { return mVinId; }
            set
            {
                mVinId = value;
                if (!string.IsNullOrEmpty(value))
                {
                    KeyStorage.Set("VIN", VinId);
                }
                PopupTitle = "Please confirm if VIN ID :" + value + " is related to Model";
                RaisePropertyChanged();
            }
        }

        private string mPopupTitl;

        public string PopupTitle
        {
            get { return mPopupTitl; }
            set
            {
                mPopupTitl = value;
                RaisePropertyChanged();
            }
        }

        private string mModelID;
        public string ModelID
        {
            get { return mModelID; }
            set
            {
                mModelID = value;
                RaisePropertyChanged();
            }
        }

        //private bool mIsShowManualSelection;

        //public bool IsShowManualSelection
        //{
        //    get { return mIsShowManualSelection; }
        //    set
        //    {
        //        mIsShowManualSelection = value;
        //        RaisePropertyChanged();
        //    }
        //}
        private bool mIsConfirmPopupVisible;
        public bool IsConfirmPopupVisible
        {
            get { return mIsConfirmPopupVisible; }
            set
            {
                mIsConfirmPopupVisible = value;
                RaisePropertyChanged();
            }
        }
        private bool mIsShowLogoutButton;
        public bool IsShowLogoutButton
        {
            get { return mIsShowLogoutButton; }
            set
            {
                mIsShowLogoutButton = value;
                RaisePropertyChanged();
            }
        }


        public ICommand ShowManualCommand { get; set; }
        public ICommand PopupConfirmCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ToggleMenuCommand { get; set; }

    }
}
