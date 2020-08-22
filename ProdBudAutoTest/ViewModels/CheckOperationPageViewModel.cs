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
            VehicleInfoList = new ObservableCollection<VehicleInfoModel>()
            {
                new VehicleInfoModel(){ TestType = "VIN No.", Desc = "MC2XXXX", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "K Factor", Desc = "13.7", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Max vehicle Speed", Desc = "", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Injector 1 trim", Desc = "Blank-fail", Result = "Fail", IsPass = false },
                new VehicleInfoModel(){ TestType = "Injector 2 trim", Desc = "Value store", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Injector 3 trim", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "PVC count", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "PVC duration", Desc = " ", Result = "Pass", IsPass = true },
            };

            VehicleInfoList2 = new ObservableCollection<VehicleInfoModel>()
            {
                new VehicleInfoModel(){ TestType = "Prameter", Desc = "MC2XXXX", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Clutch Switch", Desc = "13.7", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Brake Switch", Desc = "", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "ECO +", Desc = "Blank-fail", Result = "Fail", IsPass = false },
                new VehicleInfoModel(){ TestType = "ECO", Desc = "Value store", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Power Mode", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Accelerator Pedal", Desc = " ", Result = "Pass", IsPass = true },
             };

            VehicleInfoList3 = new ObservableCollection<VehicleInfoModel>()
            {
                new VehicleInfoModel(){ TestType = "Prameter", Desc = "MC2XXXX", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "K Factor", Desc = "13.7", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Max Speed", Desc = "", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Cluth Release", Desc = "Blank-fail", Result = "Fail", IsPass = false },
                new VehicleInfoModel(){ TestType = "Engine temp.", Desc = "Value store", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T4", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T5", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T6", Desc = " ", Result = "Pass", IsPass = true },
            };

            VehicleInfoList4 = new ObservableCollection<VehicleInfoModel>()
            {
                 new VehicleInfoModel(){ TestType = "Prameter", Desc = "MC2XXXX", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Clutch Switch", Desc = "13.7", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Brake Switch", Desc = "", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "ECO +", Desc = "Blank-fail", Result = "Fail", IsPass = false },
                new VehicleInfoModel(){ TestType = "ECO", Desc = "Value store", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Power Mode", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Accelerator Pedal", Desc = " ", Result = "Pass", IsPass = true },
            };

            VehicleInfoList5 = new ObservableCollection<VehicleInfoModel>()
            {
                new VehicleInfoModel(){ TestType = "Parameter", Desc = "MC2XXXX", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Accelerator", Desc = "13.7", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Coolant Temp.", Desc = "", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Rail Pressure", Desc = "Blank-fail", Result = "Fail", IsPass = false },
                new VehicleInfoModel(){ TestType = "ITV %", Desc = "Value store", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Exhaust Brak", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T4", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T5", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "T6", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "DP soot load%", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "DP soot KPA", Desc = " ", Result = "Pass", IsPass = true },
                new VehicleInfoModel(){ TestType = "Adblue level", Desc = " ", Result = "Pass", IsPass = true },
            };
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


        private ObservableCollection<VehicleInfoModel> mVehicleInfoList2;
        public ObservableCollection<VehicleInfoModel> VehicleInfoList2
        {
            get { return mVehicleInfoList2; }
            set
            {
                mVehicleInfoList2 = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<VehicleInfoModel> mVehicleInfoList3;
        public ObservableCollection<VehicleInfoModel> VehicleInfoList3
        {
            get { return mVehicleInfoList3; }
            set
            {
                mVehicleInfoList3 = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<VehicleInfoModel> mVehicleInfoList4;
        public ObservableCollection<VehicleInfoModel> VehicleInfoList4
        {
            get { return mVehicleInfoList4; }
            set
            {
                mVehicleInfoList4 = value;
                RaisePropertyChanged();
            }
        }


        private ObservableCollection<VehicleInfoModel> mVehicleInfoList5;
        public ObservableCollection<VehicleInfoModel> VehicleInfoList5
        {
            get { return mVehicleInfoList5; }
            set
            {
                mVehicleInfoList5 = value;
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

        private int mCurrentStepPosition;

        public int CurrentStepPosition
        {
            get { return mCurrentStepPosition; }
            set
            {
                mCurrentStepPosition = value;
                if (mCurrentStepPosition == 5)
                {
                    IsShowStepButtons = false;
                }
                RaisePropertyChanged();
            }
        }

    }
}
