using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProdBudAutoTest.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public partial class CheckOperationPageViewModel : ViewModelBase
    {
        public CheckOperationPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            StepsInitCommand();

        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
           // InitiliaseProcess();
        } 

        private ObservableCollection<VehicleInfoModel> mVehicleInfoList;
        public ObservableCollection<VehicleInfoModel> VehicleInfoList
        {
            get { return mVehicleInfoList; }
            set
            {
                mVehicleInfoList = value;
                RaisePropertyChanged();
            }
        } 

        private ObservableCollection<StepProgressInfo> mStepProgressInfo;
        public ObservableCollection<StepProgressInfo> StepProgressInfo
        {
            get { return mStepProgressInfo; }
            set
            {
                mStepProgressInfo = value;
                RaisePropertyChanged();
            }
        }


        private bool mIsShowStepButtons = true;
        public bool IsShowStepButtons
        {
            get { return mIsShowStepButtons; }
            set
            {
                mIsShowStepButtons = value;
                RaisePropertyChanged();
            }
        }

       
        public ICommand TogglePassFailCommand { get; set; }
    }
}
