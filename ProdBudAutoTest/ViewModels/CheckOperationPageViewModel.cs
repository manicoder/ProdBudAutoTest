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



    }
}
