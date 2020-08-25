using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public class ManualSelectionPageViewModel : ViewModelBase
    {
        public ManualSelectionPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

            ManualSubmitCommand = new Command((obj) =>
            {
                NavigationService.NavigateAsync("CheckOperationPage");
            });

        }
        public ICommand ManualSubmitCommand { get; set; }

    }
}
