using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace HttpClientWithDynimicProxy
{
    public class HttpClientService
    {
        private List<ProxyInfo> ProxiesList = new List<ProxyInfo>();
        public HttpClientService(List<ProxyInfo> proxy)
        {
            ProxiesList = proxy;
        }

        public string GetRandomProxy()
        {
            if (ProxiesList.Count == 0)
                throw new Exception("Not Found Proxy Config");
            int index = new Random().Next(0, ProxiesList.Count());
            return ProxiesList[index].ProxyId.ToString();
        }
        public string GetRandomProxyWithLocal()
        {
            if (ProxiesList.Count == 0)
                return "";
            int index = new Random().Next(0, ProxiesList.Count());
            return ProxiesList[index].ProxyId.ToString();
        }

        private int CurrentIndex = 0;
        public string GetSequenceProxy()
        {
            if (ProxiesList.Count == 0)
                throw new Exception("Not Found Proxy Config");
            if (CurrentIndex < ProxiesList.Count)
                return ProxiesList[CurrentIndex++].ProxyId;
            else
            {
                CurrentIndex = 0;
                return ProxiesList[CurrentIndex].ProxyId;
            }
        }
        private int CurrentIndex2 = 0;
        public string GetSequenceProxyWithLocal()
        {
            if (ProxiesList.Count == 0)
                return "";
            if (CurrentIndex2 < ProxiesList.Count)
                return ProxiesList[CurrentIndex2++].ProxyId;
            else
            {
                CurrentIndex2 = 0;
                return "";
            }
        }
    }
}
