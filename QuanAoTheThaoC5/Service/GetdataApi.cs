using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Net.Http;

namespace QuanAoTheThaoC5.Service
{
    public class GetdataApi<T> where T : class
    {
        public List<T> GetApi(string data)
        {
            var url = $"https://localhost:7001/api/";
            var httpClient= new HttpClient();
            var respones =  httpClient.GetAsync(url + data).Result;
            var dataapi =  respones.Content.ReadAsStringAsync().Result;
            var dataobj = JsonConvert.DeserializeObject<List<T>>(dataapi);
            return dataobj;
        }
    }
}
