using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Prodat.AppHelpers
{
    public static class KeyStorage
    {
        public static string Get(string key)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key] as string;
            }
            return "";
        }
        public static async void Set(string key, string value)
        {
            Application.Current.Properties[key] = value;
            await Application.Current.SavePropertiesAsync();
        }
        public static async void Remove(string key)
        {
            Application.Current.Properties.Remove(key);
            await Application.Current.SavePropertiesAsync();
        }
    }
}
