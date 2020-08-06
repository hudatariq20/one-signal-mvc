using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneSignalAppManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OneSignalAppManager.Gateway
{
    public class OneSignalGateway
    {
        private HttpClient client;
        private readonly string BASE_URL;
        private readonly string BASIC_AUTH;
        private static readonly string APP_URL = "api/v1/apps/";

        public OneSignalGateway(IConfiguration configuration)
        {
            BASE_URL = configuration["OneSignal:Endpoint"];
            BASIC_AUTH = configuration["OneSignal:Token"];
            client = new HttpClient();
        }

        public async Task<OneSignalModel> getAppById(string id)
        {
            string path = APP_URL + id;

            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(BASIC_AUTH);
            
            HttpResponseMessage Res = await client.GetAsync(path);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsAsync<OneSignalModel>();
                return response;
            }
            return null;
        }

        public async Task<List<OneSignalModel>> getAllApps()
        {
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(BASIC_AUTH);

            HttpResponseMessage Res = await client.GetAsync(APP_URL);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsAsync<List<OneSignalModel>>();
                return response;
                    
            }
            return null;
        }

        public async Task<OneSignalModel> createApps(OneSignalCreateModel model)
        {
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(BASIC_AUTH);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage Res = await client.PostAsync(APP_URL, requestContent);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsAsync<OneSignalModel>();
                return response;
            }
            return null;
        }

        public async Task<OneSignalModel> updateApp(string id, OneSignalCreateModel model)
        {
            string path = APP_URL + id;

            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(BASIC_AUTH);

            var requestContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                  
            HttpResponseMessage Res = await client.PutAsync(path, requestContent);

            //Checking the response is successful or not which is sent using HttpClient  
            if (Res.IsSuccessStatusCode)
            {
                var response = await Res.Content.ReadAsAsync<OneSignalModel>();
                return response;
            }
            return null;   
        }
    }
}
