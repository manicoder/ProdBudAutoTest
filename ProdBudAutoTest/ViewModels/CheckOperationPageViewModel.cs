using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
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

   
    }
}
