using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ProdBudAutoTest.ViewModels
{
    public class BarcodeScanPageViewModel : ViewModelBase
    {
        public BarcodeScanPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            await CheckAndRequestLocationPermission();
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
            var showDialog = await this.PageDialogService.DisplayActionSheetAsync("Confirm if Model is related to VIN " + VinId  + "\n Model: 123456", "Manual", "Confirm");
            if (showDialog == "Confirm")
            {
                NavigationService.NavigateAsync("CheckOperationPage");
            }
            else
            {

            }
        }

        private string mVinId;
        public string VinId
        {
            get { return mVinId; }
            set
            {
                mVinId = value;
                RaisePropertyChanged();
            }
        }

    }
}
