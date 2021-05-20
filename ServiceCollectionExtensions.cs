using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HttpClientWithDynimicProxy
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClientWithDynimicProxy(this IServiceCollection services, IConfiguration config)
        {
            services.AddHttpClient();
            List<ProxyInfo> ProxiesList = new List<ProxyInfo>();
            config.GetSection("Proxies").Bind(ProxiesList);
            foreach (var item in ProxiesList)
            {
                item.ProxyId = Guid.NewGuid().ToString();
                services.AddHttpClient(item.ProxyId).ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler
                    {
                        Proxy = new WebProxy()
                        {
                            Address = new Uri(item.URL),
                            Credentials = new NetworkCredential(userName: item.UserName, password: item.Password)
                        }
                    };
                });
            }
            services.AddSingleton<HttpClientService>(a => new HttpClientService(ProxiesList));
            services.AddTransient<HttpClientWithProxy>();
            return services;
        }
    }
}
