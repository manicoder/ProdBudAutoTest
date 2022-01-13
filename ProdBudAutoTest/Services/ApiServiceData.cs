using Prodat.AppHelpers;
using Prodat.Models;
using Proddat.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Prodat.Services
{
    public class ApiServiceData
    {
        IApiServices apiServices;
        public ApiServiceData(IApiServices services)
        {
            apiServices = services;
        }
        public async Task<UserMessageResponse> Login(UserModel model)
        {
            return await apiServices.LoginAsync(model);
        }
        public async Task<StationData> GetAllStations()
        {
            var token = KeyStorage.Get("token");
            return await apiServices.GetAllStationsAsync();
        }
        public async Task<string> GetAllStationsRaw()
        {
            var token = KeyStorage.Get("token");
            return await apiServices.GetAllStationsRawAsync();
        }
    }
}
