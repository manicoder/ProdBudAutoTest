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
    public class BarcodeScanPageViewModel : ViewModelBase
    {
        public BarcodeScanPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {
            PopupConfirmCommand = new Command((obj) =>
            {
                GoToNextPgae();
                if (obj is string param)
                {
                    if (param == "Confirm")
                    {
                        NavigationService.NavigateAsync("CheckOperationPage");
                    }
                    else
                    {
                        if (IsShowManualSelection)
                        {
                            IsShowManualSelection = false;
                        }
                        else
                        {
                            IsShowManualSelection = true;
                        }
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
                if (obj is string model)
                {
                    this.ModelID = model;
                }
                if (IsShowManualSelection)
                {
                    IsShowManualSelection = false;
                }
                else
                {
                    IsShowManualSelection = true;
                }

            });

            ManualSubmitCommand = new Command((obj) =>
            {
                if (obj is string model)
                {
                    this.ModelID = model;
                }

                NavigationService.NavigateAsync("CheckOperationPage");

                Task.Delay(100);
                IsShowManualSelection = false;
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

        public async void GoToNextPgae()
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

        private bool mIsShowManualSelection;

        public bool IsShowManualSelection
        {
            get { return mIsShowManualSelection; }
            set
            {
                mIsShowManualSelection = value;
                RaisePropertyChanged();
            }
        }
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

        public ICommand ShowManualCommand { get; set; }
        public ICommand ManualSubmitCommand { get; set; }
        public ICommand PopupConfirmCommand { get; set; }
    }
}
