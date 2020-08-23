using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using ProdBudAutoTest.DPService;
using ProdBudAutoTest.Droid.DPService;
using Xamarin.Forms;
[assembly: Dependency(typeof(KeyBoardHelperService))]
namespace ProdBudAutoTest.Droid.DPService
{
    public class KeyBoardHelperService : IKeyboardHelper
    {
        public KeyBoardHelperService()
        {

        }


        //public void HideKeyboard()
        //{
        //    var context = Forms.Context;
        //    var inputMethodManager = context.GetSystemService(Context.InputMethodService) as InputMethodManager;
        //    if (inputMethodManager != null && context is Activity)
        //    {
        //        var activity = context as Activity;
        //        var token = activity.CurrentFocus?.WindowToken;
        //        inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

        //       // activity.Window.DecorView.ClearFocus();
        //    }
             
        //}

        public void HideKeyboard()
        {
            var inputMethodManager = Xamarin.Forms.Forms.Context.GetSystemService(Context.InputMethodService) as InputMethodManager;
            if (inputMethodManager != null && Xamarin.Forms.Forms.Context is Activity)
            {
                var activity = Xamarin.Forms.Forms.Context as Activity;
                var token = activity.CurrentFocus == null ? null : activity.CurrentFocus.WindowToken;
                inputMethodManager.HideSoftInputFromWindow(token, 0);
            }
        }
    }
}