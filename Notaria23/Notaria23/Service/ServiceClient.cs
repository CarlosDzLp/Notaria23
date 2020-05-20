using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Notaria23.Helpers;
using Notaria23.Models.Authenticate;

namespace Notaria23.Service
{
    public class ServiceClient : IServiceClient
    {
        public async Task<T> Delete<T>(string url)
        {
            try
            {
                var token = await Authenticate();
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urltype = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.DeleteAsync(urltype);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Get<T>(string url)
        {
            try
            {
                var token = await Authenticate();
                T deserializer = default(T);
                HttpClient client = new HttpClient();
                var urlType = Settings.URL + url;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.GetAsync(urlType);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Post<T, K>(K deserialice, string url)
        {
            try
            {
                var token = await Authenticate();
                T deserializer = default(T);
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(deserialice);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.PostAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<T> Put<T, K>(K deserialice, string url)
        {
            try
            {
                var token = await Authenticate();
                T deserializer = default(T);
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(deserialice);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(serializer, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                var response = await client.PutAsync(url, content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        public async Task<TokenRequest> Authenticate()
        {
            try
            {
                var deserializer = new TokenRequest();
                var tokenModel = new AuthenticateModel
                {
                    User = "ryankar90@hotmail.com",
                    Password = "carlosdiaz90#"
                };
                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(tokenModel);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Settings.URL);
                HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("authenticate/aouth", content);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    deserializer = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenRequest>(responseString);
                }
                return deserializer;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
