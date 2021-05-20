# HttpClientWithDynimicProxy
## Usage
### Step1:Add proxy info
```JavaScript
 "Proxies": [
    {
      "URL": "http://127.0.0.1:1212",
      "UserName": "user",
      "Password": "pwd"
    },
    {
      "URL": "http://192.168.0.1:11212",
      "UserName": "usr",
      "Password": "pwd"
    }
  ]
```
### Step2:Add code to ConfigureServices function
```C#
 services.AddHttpClientWithDynimicProxy(Configuration);
```
### Step3:Create HttpClient in the controller or service
```C#
HttpClientWithProxy _client;
        public ValuesController(HttpClientWithProxy client)
        {
            _client = client;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var cli = _client.CreateClient();
            return await cli.GetStringAsync("http://www.baidu.com");
        }
```