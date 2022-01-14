using Prodat.Models;
using ProdBudAutoTest.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proddat.Services
{
    public interface IApiServices
    {
        Task<UserMessageResponse> LoginAsync(UserModel model);
        Task<StationData> GetAllStationsAsync();
        Task<string> GetAllStationsRawAsync();
        Task<StationData> GetStationDataAsync();
        Task<VinResponse> GetVinNumberAsync(string token, string vinNumber);
        Task<ModelsResponse> GetAllModelsAsync();
    }
}
