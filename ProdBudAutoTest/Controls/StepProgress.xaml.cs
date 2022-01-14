using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProdBudAutoTest.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepProgress : ContentView
    {
        public StepProgress()
        {
            InitializeComponent();
            this.BindingContextChanged += StepProgress_BindingContextChanged;
        }

        private void StepProgress_BindingContextChanged(object sender, EventArgs e)
        {
            var a = sender as View;
            var b = a.BindingContext;
        }
    }
}