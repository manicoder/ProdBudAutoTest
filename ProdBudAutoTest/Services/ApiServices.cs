using Newtonsoft.Json;
using Prodat;
using Prodat.AppHelpers;
using Prodat.Models;
using ProdBudAutoTest.Models;
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
                var response = await client.PostAsync($"{BaseUrl}accounts/prodbud-login/", content);//.ConfigureAwait(false);
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

        public async Task<StationData> GetAllStationsAsync()
        {
            try
            {
                client = new HttpClient();
                var response = await client.GetAsync($"{BaseUrl}stations/all-station-list");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
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
        public async Task<StationData> GetStationDataAsync()
        {
            var data = await FileSystemHelper.Instance.ReadDataAsync(AppConstants.StationsFileName);
            return JsonConvert.DeserializeObject<StationData>(data);
        }
        public async Task<string> GetAllStationsRawAsync()
        {
            try
            {
                client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("JWT", token);
                var response = client.GetAsync($"{BaseUrl}stations/all-station-list").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    if (data != null)
                    {
                        //Store locally
                        await FileSystemHelper.Instance.SaveDataAsync(AppConstants.StationsFileName, data);
                    }
                    return data;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<VinResponse> GetVinNumberAsync(string token, string vinNumber)
        {
            try
            {
                client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "JWT " + token);
                var response = await client.GetAsync($"{BaseUrl}fert_model/get-delphi/?chassis_id=" + vinNumber);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var stationData = JsonConvert.DeserializeObject<VinResponse>(data);
                    return stationData;
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ModelsResponse> GetAllModelsAsync()
        {
            try
            {

                if (FileSystemHelper.Instance.IsFileExists(AppConstants.ModelsFilename))
                {
                    var data = await FileSystemHelper.Instance.ReadDataAsync(AppConstants.ModelsFilename);
                    if (!string.IsNullOrEmpty(data))
                    {
                        var modelData = JsonConvert.DeserializeObject<ModelsResponse>(data);
                        return modelData;
                    }
                    else {
                        return await GetModelServiceData();
                    }
                }
                else
                {
                  return await GetModelServiceData();
                }
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<ModelsResponse> GetModelServiceData() {
            client = new HttpClient();
            var response = client.GetAsync($"{BaseUrl}models/get-models/").Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(data))
                {
                    await FileSystemHelper.Instance.SaveDataAsync(AppConstants.ModelsFilename, data);
                    var modelData = JsonConvert.DeserializeObject<ModelsResponse>(data);
                    return modelData;
                }
                else return null;
            }
            else return null;
        }
    }
}
