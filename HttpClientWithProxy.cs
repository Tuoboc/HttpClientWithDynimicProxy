using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace HttpClientWithDynimicProxy
{
    public class HttpClientWithProxy
    {
        HttpClientService ProxyService;
        IHttpClientFactory _clientFactory;
        public HttpClientWithProxy(IHttpClientFactory clientFactory, HttpClientService httpClientService)
        {
            ProxyService = httpClientService;
            _clientFactory = clientFactory;
        }
        /// <summary>
        /// Get a HttpClient one by one.If the config file doesn't contain any proxy info,The request always not apply proxy.
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateClient()
        {
            string id = ProxyService.GetSequenceProxyWithLocal();
            return _clientFactory.CreateClient(id);
        }
        /// <summary>
        /// Get a HttpClient without localhost one by one.If the config file doesn't contain any proxy info,An exception will be thrown.
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateClientWithoutLocal()
        {
            string id = ProxyService.GetSequenceProxy();
            return _clientFactory.CreateClient(id);
        }
        /// <summary>
        /// Get a random HttpClient without localhost.If the config file doesn't contain any proxy info,An exception will be thrown.
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateRandomClientWithoutLocal()
        {
            string id = ProxyService.GetRandomProxy();
            return _clientFactory.CreateClient(id);
        }
        /// <summary>
        /// Get a random HttpClient.If the config file doesn't contain any proxy info,The request always not apply proxy.
        /// </summary>
        /// <returns></returns>
        public HttpClient CreateRandomClient()
        {
            string id = ProxyService.GetRandomProxyWithLocal();
            return _clientFactory.CreateClient(id);
        }
    }
}
