using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DoctorWho.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DoctorWho.Tests.Utils
{
    public static class ResponseParser
    {
        public static async Task<T> GetObjectFromResponse<T>(HttpResponseMessage response)
        {
            string data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static StringContent GetResponseBody(object bodyObject)
        {
            return new(JsonSerializer.Serialize(bodyObject),Encoding.UTF8,"application/json");
        }
    }
}