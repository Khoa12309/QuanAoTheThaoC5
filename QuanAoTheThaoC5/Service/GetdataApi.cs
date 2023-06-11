using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuanAoTheThaoC5.Models;
using System.Net.Http;

namespace QuanAoTheThaoC5.Service
{
    public class GetdataApi<T> where T : class
    {
        public async Task<List<T>> GetApiAsync(string data)
        {
            var url = $"https://localhost:7001/api/";
            var httpClient= new HttpClient();
            var respones = await httpClient.GetAsync(url + data);
            var dataapi = await respones.Content.ReadAsStringAsync();
            var dataobj = JsonConvert.DeserializeObject<List<T>>(dataapi);
            return dataobj;
        }
    }
}
