using Xamarin.Forms;

namespace ProdBudAutoTest.Views
{
    public partial class CheckOperationPage : ContentPage
    {
        public CheckOperationPage()
        {
            InitializeComponent();
        }



        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 1;
        }

        private void Button_Clicked_2(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 2;
        }

        private void Button_Clicked_3(object sender, System.EventArgs e)
        {
            Utils.AppUtils.CurrentStep = 3;
        }

      

    }
}
