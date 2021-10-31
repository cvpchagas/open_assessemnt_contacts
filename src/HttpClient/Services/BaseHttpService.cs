
using HttpClientService.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientService.Services
{
    public class BaseHttpService : IBaseHttpService
    {

        private readonly HttpClient _httpClient;

        public BaseHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<KeyValuePair<HttpStatusCode, dynamic>> SendResquestMessageAsync<T>(HttpMethod httpMethod, string requestUri, object objectToSend = null, List<KeyValuePair<string, string>> headerList = null, KeyValuePair<string, string> authorization = default)
        {
            try
            {
                SetAuthorization(authorization);
                SetHeaderByRequest(headerList);

                var requestMessage = new HttpRequestMessage
                {
                    RequestUri = new Uri($"{_httpClient.BaseAddress}{requestUri}"),
                    Method = httpMethod
                };

                if (objectToSend != null)
                    requestMessage.Content = CreateContent(objectToSend);

                using (var cts = new CancellationTokenSource(_httpClient.Timeout))
                {
                    var responseMessage = await _httpClient.SendAsync(requestMessage, cts.Token);

                    var contentRange = responseMessage.Content.Headers.FirstOrDefault(x => x.Key.Equals("Content-Range"));

                    return await ReadResponse<T>(responseMessage);
                }
            }
            catch (TaskCanceledException ex)
            {
                return new KeyValuePair<HttpStatusCode, dynamic>(HttpStatusCode.InternalServerError, ex.Message);

            }
            catch (Exception ex)
            {
                return new KeyValuePair<HttpStatusCode, dynamic>(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async Task<KeyValuePair<HttpStatusCode, dynamic>> ReadResponse<T>(HttpResponseMessage responseMessage)
        {
            var contentResponse = string.Empty;

            if (responseMessage?.Content != null)
                contentResponse = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage?.StatusCode == HttpStatusCode.OK || responseMessage?.StatusCode == HttpStatusCode.PartialContent)
                return new KeyValuePair<HttpStatusCode, dynamic>(responseMessage.StatusCode, JsonConvert.DeserializeObject<T>(contentResponse));
            else if (responseMessage?.StatusCode == HttpStatusCode.ServiceUnavailable || responseMessage?.StatusCode == HttpStatusCode.InternalServerError)
                return new KeyValuePair<HttpStatusCode, dynamic>(responseMessage.StatusCode, string.Concat(contentResponse, "Uri: " , responseMessage.RequestMessage.RequestUri));
            else
                return new KeyValuePair<HttpStatusCode, dynamic>(responseMessage.StatusCode, contentResponse);

        }

        protected StringContent CreateContent(object objectToSend)
         => new StringContent(JsonConvert.SerializeObject(objectToSend), Encoding.UTF8, "application/json");

        protected void SetHeaderByRequest(List<KeyValuePair<string, string>> headerList)
        {
            if (headerList != null && headerList.Any())
                foreach (var headerItem in headerList)
                    _httpClient.DefaultRequestHeaders.Add(headerItem.Key, headerItem.Value);
        }

        protected void SetAuthorization(KeyValuePair<string, string> authorization)
        {
            if (!string.IsNullOrWhiteSpace(authorization.Key) && !string.IsNullOrWhiteSpace(authorization.Value))
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authorization.Key, authorization.Value);
        }

        protected HttpContent CreateContentUrlEncoded(IEnumerable<KeyValuePair<string, string>> objectFormUrl)
             => new FormUrlEncodedContent(objectFormUrl);
    }
}
