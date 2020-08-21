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
    public partial class TextBox : ContentView
    {
        public TextBox()
        {
            InitializeComponent();
        }
      
       
        public string PlaceHolder
        {
            get { return txt.Placeholder; }
            set { txt.Placeholder = value; }
        }
        public bool IsPassword
        {
            get { return txt.IsPassword; }
            set { txt.IsPassword = value; }
        }
    }
}