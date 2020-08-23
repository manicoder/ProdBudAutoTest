using ProdBudAutoTest.Models;
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
    public partial class Step4View : ContentView
    {
        public Step4View()
        {
            InitializeComponent();
        }
        private void Pass_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;
            var context = button.BindingContext as VehicleInfoModel;
            var param = button.CommandParameter;
            if (param is string stype)
            {
                switch (stype)
                {
                    case "nil":
                        context.IsFail = true;
                        context.IsPass = false;
                        context.IsNil = false;
                        break;
                    case "fail":
                        context.IsFail = false;
                        context.IsPass = true;
                        context.IsNil = false;
                        break;
                    case "pass":
                        context.IsFail = false;
                        context.IsPass = false;
                        context.IsNil = true;
                        break;
                    default:
                        break;
                }
                context.RaisePropertyChanged("IsFail");
                context.RaisePropertyChanged("IsPass");
                context.RaisePropertyChanged("IsNil");
            }
        }
    }
}