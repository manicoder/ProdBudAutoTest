using Prism;
using Prism.Ioc;
using ProdBudAutoTest.ViewModels;
using ProdBudAutoTest.Views;
using Xamarin.Essentials.Interfaces;
using Xamarin.Essentials.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Lato-Bold.ttf", Alias = "FontBold")]
[assembly: ExportFont("Lato-Regular.ttf", Alias = "FontRegular")]
[assembly: ExportFont("Lato-Light.ttf", Alias = "FontLight")]
//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProdBudAutoTest
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/CheckOperationPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CheckOperationPage, CheckOperationPageViewModel>();
        }
    }
}
