using Prodat.Models;
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
        Task<StationData> GetAllStationsAsync(string token);
        Task<string> GetAllStationsRawAsync(string token);

    }
}
