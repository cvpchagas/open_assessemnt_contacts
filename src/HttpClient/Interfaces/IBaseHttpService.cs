using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientService.Interfaces
{
    public interface IBaseHttpService
    {
        Task<KeyValuePair<HttpStatusCode, dynamic>> SendResquestMessageAsync<T>(HttpMethod httpMethod, string requestUri, object objectToSend = null, List<KeyValuePair<string, string>> headerList = null, KeyValuePair<string, string> authorization = default);
    }
}
