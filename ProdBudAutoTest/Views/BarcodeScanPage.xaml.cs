using ProdBudAutoTest.ViewModels;
using Xamarin.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class BarcodeScanPage : ContentPage
    {
        public BarcodeScanPage()
        {
            InitializeComponent();
            this.SizeChanged += BarcodeScanPage_SizeChanged;

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
            scanView.IsScanning = true;
            // animate(cornerImage);
        }
        bool isAnimation = true;
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            scanView.IsAnalyzing = false;
            scanView.IsScanning = false;
            isAnimation = false;
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

        void Handle_OnScanResult(ZXing.Result result)
        {
            if (txt.Text.Length == 17)
            {
                var context = this.BindingContext as BarcodeScanPageViewModel;
                context.VinId = result.Text;
                scanView.IsScanning = false;
                this.AbortAnimation("fadeAnimation");
            }
        }

        private void CustomEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt.Text.Length == 17)
            {
                var context = this.BindingContext as BarcodeScanPageViewModel;
                context.GoToNextPgae();
                context.VinId = "";
            }
        }
    }

}
