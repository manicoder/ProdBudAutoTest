using Prism;
using Prism.Ioc;
using ProdBudAutoTest.ViewModels;
using ProdBudAutoTest.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prodat.Services;
using System;
using Prodat.AppHelpers;
using Proddat.Services;

[assembly: ExportFont("Lato-Bold.ttf", Alias = "FontBold")]
[assembly: ExportFont("Lato-Regular.ttf", Alias = "FontRegular")]
[assembly: ExportFont("Lato-Light.ttf", Alias = "FontLight")]
[assembly: ExportFont("Lato-Black.ttf", Alias = "FontExtraBold")]
//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProdBudAutoTest
{
    public partial class App
    {
        public static string JwtToken = string.Empty;
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationController();
        }

        private async void NavigationController()
        {
            try
            {
                var user_key = KeyStorage.Get("firstName");
                if (!string.IsNullOrEmpty(user_key))
                {
                    await NavigationService.NavigateAsync("NavigationPage/BarcodeScanPage");
                }
                else
                {
                    await NavigationService.NavigateAsync("NavigationPage/LoginPage");
                }
            }
            catch (Exception ex) { }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CheckOperationPage, CheckOperationPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterForNavigation<BarcodeScanPage, BarcodeScanPageViewModel>();
            containerRegistry.RegisterForNavigation<ManualSelectionPage, ManualSelectionPageViewModel>();

            //services
            containerRegistry.Register<IApiServices, ApiServices>();
        }
    }
}
