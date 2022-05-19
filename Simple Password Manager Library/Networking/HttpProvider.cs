using Newtonsoft.Json;
using SimplePM.Library.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplePM.Library.Networking
{
    internal class HttpProvider
    {
        internal static HttpClient client = new HttpClient(new RetryHandler(new HttpClientHandler()));


        /// <summary>
        /// Creates HTTP Request with parameters and sends it to corresponding service
        /// </summary>
        /// <typeparam name="T">Any object that is "class". If content is null, T can be any nullable class</typeparam>
        /// <param name="method">HTTP method of request</param>
        /// <param name="serviceType">Type of API service which would proceed this request </param>
        /// <param name="additionToUri">Any addition to URI</param>
        /// <param name="content">Any content that should be passed with request</param>
        /// <param name="headers">Additional headers of request as dictionary where key is header name and value is header value</param>
        /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
        /// <exception cref="InvalidOperationException">The request message was already sent by the System.Net.Http.HttpClient instance.</exception>
        /// <returns>Returns Tuple<bool, string> where item1 represents successfulness of response and item2 is response as json string</bool></returns>
        internal static async Task<HttpResponseResult> CreateAndSend<T>(HttpMethod method, ServiceType serviceType, string additionToUri = null, T content = null, Dictionary<string, string> stringHeaders = null, Dictionary<string, string[]> arrayHeaders = null ) where T: class
        {
            string uri = "";
            switch (serviceType)
            {
                case ServiceType.Entries:
                    uri = ServicesURIs.EntriesServiceUri;
                    break;
                case ServiceType.MasterPassword:
                    uri = ServicesURIs.MasterPasswordServiceUri;
                    break;
                case ServiceType.Accounts:
                    uri = ServicesURIs.AccountsServiceUri;
                    break;
                case ServiceType.RSA:
                    uri = ServicesURIs.RsaServiceUri;
                    break;
                case ServiceType.Test:
                    uri = ServicesURIs.TestServiceUri;
                    break;
            }
            if (additionToUri != null)
            {
                uri = System.IO.Path.Combine(uri, additionToUri);
            }
            var request = new HttpRequestMessage(method, uri);
            if (content != null)
            {
                var jsonData = JsonConvert.SerializeObject(content);
                var buffer = Encoding.UTF8.GetBytes(jsonData);
                request.Content = new ByteArrayContent(buffer);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }
            if (stringHeaders != null)
            {
                foreach (var header in stringHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            if (arrayHeaders != null)
            {
                foreach (var header in arrayHeaders)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            HttpResponseMessage response = await client.SendAsync(request);
            using (HttpContent incomingContent = response.Content)
            {
                string incomingJson = incomingContent.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    return new HttpResponseResult(true, incomingJson);
                }
                else
                {
                    return new HttpResponseResult(false, $"{response.StatusCode}: {response.ReasonPhrase}");
                }
            }
        }
    }
}
