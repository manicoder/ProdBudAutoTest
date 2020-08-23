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
    public partial class ALertPopupView : ContentView
    {
        public ALertPopupView()
        {
            InitializeComponent();
        }

        public string Text1
        {
            get { return txt1.Text; }
            set { txt1.Text = value; }
        }

    }
}