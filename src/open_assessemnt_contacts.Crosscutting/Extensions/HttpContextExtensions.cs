using System.Net.Http;
using System.Threading.Tasks;

namespace Open.Assessement.Contacts.Crosscutting.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent content) =>
        await System.Text.Json.JsonSerializer.DeserializeAsync<T>(await content.ReadAsStreamAsync());
    }
}