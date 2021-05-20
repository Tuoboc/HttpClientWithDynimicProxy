using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientWithDynimicProxy
{
    public class ProxyInfo
    {
        public string URL { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string ProxyId { get; set; }
        public int ErrorTimes { get; set; }
    }
}
