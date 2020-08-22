using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProdBudAutoTest.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool mIsBusy;
        public bool IsBusy
        {
            get { return mIsBusy; }
            set
            {
                mIsBusy = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
            InitView();
        }
        public ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
            InitView();
        }
        private void InitView()
        {
            GoHomePageCommand = new Command(() => { NavigationService.GoBackAsync(); });

        }
        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }

        public ICommand GoHomePageCommand { get; set; }
    }
}
