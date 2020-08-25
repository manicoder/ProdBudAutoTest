using ProdBudAutoTest.DPService;
using ProdBudAutoTest.ViewModels;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class BarcodeScanPage : ContentPage
    {
        public BarcodeScanPage()
        {
            InitializeComponent();
            this.SizeChanged += BarcodeScanPage_SizeChanged;
            var context = this.BindingContext as BarcodeScanPageViewModel;


            scanView.OnScanResult += (result) => Device.BeginInvokeOnMainThread(async () =>
{
    if (!string.IsNullOrWhiteSpace(result.Text))
    {
        scanView.IsAnalyzing = false;
        if (result.Text.Length == 17)
            context.VinId = result.Text;
        else
        {
            await context.PageDialogService.DisplayAlertAsync("Not Support", result.Text + " is not valid barcode. Please try again.", "OK");
            scanView.IsAnalyzing = true;
        }
    }
});



            //defaultOverlay.ShowFlashButton = scanView.HasTorch;
            //defaultOverlay.FlashButtonClicked += (sender, e) =>
            //{
            //    scanView.IsTorchOn = !scanView.IsTorchOn;
            //};

        }

        private void BarcodeScanPage_SizeChanged(object sender, System.EventArgs e)
        {
            var page = sender as ContentPage;
            var h = page.Height;
            var w = page.Width;
            scanGrid.HeightRequest = w;
            scanGrid.WidthRequest = w;
            scanView.HeightRequest = w;
            scanView.WidthRequest = w;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            scanView.IsAnalyzing = true;
            scanView.AutoFocus();

            // animate(cornerImage);
        }
        bool isAnimation = true;
        protected override void OnDisappearing()
        {
            //scanView.IsScanning = false;
            //scanView.IsAnalyzing = false;
            // isAnimation = false;
            base.OnDisappearing();

            //  this.AbortAnimation("fadeAnimation");
            //  fadeAnimation = null;
        }

        Animation fadeAnimation = null;

        void animate(Image image)
        {
            var fadeAnimation = new Animation
            {
                {
                    0,
                    0.5,
                    new Animation((v) =>
           {
               image.Opacity = v;
           }, 0.0, 1.0, Easing.CubicInOut, () => { })
                },
                {
                    0.5,
                    1,
                    new Animation((v) =>
           {
               image.Opacity = v;
           }, 1.0, 0.0, Easing.CubicInOut, () => { })
                }
            };
            fadeAnimation.Commit(image, "fadeAnimation", 16, 1000, repeat: () => isAnimation);
            //{
            //    if (isAnimation)
            //    {
            //        animate(image);
            //    }
            //});
        }


        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt.Text.Length == 17)
            {
                //DependencyService.Get<IKeyboardHelper>().HideKeyboard();
                popup.Focus();
                var context = this.BindingContext as BarcodeScanPageViewModel;
                context.GoToNextPgae();
                //  scanView.IsAnalyzing = true;
                // context.VinId = "";
            }
        }
    }

}
