using Newtonsoft.Json;
using Prodat;
using Prodat.AppHelpers;
using Prodat.Models;
using Proddat.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prodat.Services
{
    public class ApiServices : IApiServices
    {
        HttpClient client;
        public string BaseUrl = "https://vecvdaliteplus.vecv.net/api/v1/";

        public async Task<UserMessageResponse> LoginAsync(UserModel model)
        {
            UserMessageResponse loginRespons = new UserMessageResponse();
            try
            {
                client = new HttpClient();
                var json = JsonConvert.SerializeObject(model);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync($"{BaseUrl}accounts/prodbud-login/", content).Result;//.ConfigureAwait(false);
                var Data = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var UserInfo = JsonConvert.DeserializeObject<UserMessageResponse>(Data);

                    KeyStorage.Set("token", UserInfo.token);
                    loginRespons = UserInfo;
                }
                else
                {
                    loginRespons = JsonConvert.DeserializeObject<UserMessageResponse>(Data);
                    return loginRespons;
                }
                return loginRespons;

            }
            catch (Exception ex)
            {
                loginRespons = null;
                return loginRespons;
            }
        }

        public async Task<StationData> GetAllStationsAsync(string token)
        {
            try
            {
                client = new HttpClient();
                var response = client.GetAsync($"{BaseUrl}stations/all-station-list").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    var stationData = JsonConvert.DeserializeObject<StationData>(data);
                    return stationData;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> GetAllStationsRawAsync(string token)
        {
            try
            {
                client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", token);
                var response = client.GetAsync($"{BaseUrl}stations/all-station-list").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    return data;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
