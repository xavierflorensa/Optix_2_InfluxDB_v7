#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.Retentivity;
using FTOptix.NativeUI;
using FTOptix.CoreBase;
using FTOptix.Core;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

public class RESTApiClient : BaseNetLogic
{
    readonly struct HTTPResponse
    {
        public HTTPResponse(string payload, int code)
        {
            Payload = payload;
            Code = code;
        }

        public string Payload { get; }
        public int Code { get; }
    };

    public override void Start()
    {
    }

    public override void Stop()
    {
    }

    private long GetTimeout()
    {
        var timeoutVariable = LogicObject.Get<IUAVariable>("Timeout");
        if (timeoutVariable == null)
            throw new Exception($"Missing Timeout variable under the NetLogic {LogicObject.BrowseName}");

        return timeoutVariable.Value;
    }

    private string GetUserAgent()
    {
        var userAgentVariable = LogicObject.Get<IUAVariable>("UserAgent");
        if (userAgentVariable == null)
            throw new Exception($"Missing UserAgent variable under the NetLogic {LogicObject.BrowseName}");

        return userAgentVariable.Value;
    }

    private bool IsSupportedScheme(string scheme)
    {
        return scheme == "http" || scheme == "https";
    }

    private bool IsSecureScheme(string scheme)
    {
        return scheme == "https";
    }

    private HttpRequestMessage BuildGetMessage(Uri url, string userAgent, string bearerToken)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

        if (!string.IsNullOrWhiteSpace(userAgent))
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(userAgent)));

        if (!string.IsNullOrWhiteSpace(bearerToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        return request;
    }

    private HttpRequestMessage BuildPostMessage(Uri url, string body, string contentType, string userAgent, string bearerToken)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);

        if (!string.IsNullOrWhiteSpace(body))
            request.Content = new StringContent(body, System.Text.Encoding.UTF8, contentType);

        if (!string.IsNullOrWhiteSpace(userAgent))
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(userAgent)));

        if (!string.IsNullOrWhiteSpace(bearerToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
        
        //
        var Variable3 = Project.Current.GetVariable("Model/Variable3");
        Variable3.Value =body ;
        //
        return request;
    }

    private HttpRequestMessage BuildPutMessage(Uri url, string body, string contentType, string userAgent, string bearerToken)
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);

        if (!string.IsNullOrWhiteSpace(body))
            request.Content = new StringContent(body, System.Text.Encoding.UTF8, contentType);

        if (!string.IsNullOrWhiteSpace(userAgent))
            request.Headers.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(userAgent)));

        if (!string.IsNullOrWhiteSpace(bearerToken))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

        return request;
    }

    private async Task<HTTPResponse> PerformRequest(HttpRequestMessage request, TimeSpan timeout)
    {
        HttpClient client = new HttpClient();
        client.Timeout = timeout;

        using HttpResponseMessage httpResponse = await client.SendAsync(request);
        string responseBody = await httpResponse.Content.ReadAsStringAsync();

        return new HTTPResponse(responseBody, (int)httpResponse.StatusCode);
    }

    private HttpRequestMessage BuildMessage(HttpMethod verb, Uri url, string requestBody, string bearerToken, string contentType)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(GetTimeout());
        string userAgent = GetUserAgent();

        if (string.IsNullOrWhiteSpace(contentType))
            contentType = "application/json";

        if (!IsSupportedScheme(url.Scheme))
            throw new Exception($"The URI scheme {url.Scheme} is not supported");

        if (!IsSecureScheme(url.Scheme) && !string.IsNullOrWhiteSpace(bearerToken))
            Log.Warning("Possible sending of unencrypted confidential information");

        if (verb == HttpMethod.Get)
            return BuildGetMessage(url, userAgent, bearerToken);
        if (verb == HttpMethod.Post)
            return BuildPostMessage(url, requestBody, contentType, userAgent, bearerToken);
        if (verb == HttpMethod.Put)
            return BuildPutMessage(url, requestBody, contentType, userAgent, bearerToken);

        throw new Exception($"Unsupported verb { verb }");
    }

    [ExportMethod]
    public void Get(string apiUrl, string queryString, string bearerToken, out string response, out int code)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(GetTimeout());
        UriBuilder uriBuilder = new UriBuilder(apiUrl);
        uriBuilder.Query = queryString;

        var requestMessage = BuildMessage(HttpMethod.Get, uriBuilder.Uri, "", bearerToken, "");
        var requestTask = PerformRequest(requestMessage, timeout);
        var httpResponse = requestTask.Result;

        (response, code) = (httpResponse.Payload, httpResponse.Code);
    }

    [ExportMethod]
    public void Post(string apiUrl, string requestBody, string bearerToken, string contentType, out string response, out int code)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(GetTimeout());
        UriBuilder uriBuilder = new UriBuilder(apiUrl);
        //
        var Variable1 = Project.Current.GetVariable("Model/Variable1");
        var Variable2 = Project.Current.GetVariable("Model/Variable2");
        //Variable1.Value ="Hello World";
        //


        var requestMessage = BuildMessage(HttpMethod.Post, uriBuilder.Uri, requestBody, bearerToken, contentType);
        var requestTask = PerformRequest(requestMessage, timeout);
        var httpResponse = requestTask.Result;

        //
        Variable1.Value =httpResponse.Payload;
        Variable2.Value =httpResponse.Code;
        //

        (response, code) = (httpResponse.Payload, httpResponse.Code);
    }

    [ExportMethod]
    public void Put(string apiUrl, string requestBody, string bearerToken, string contentType, out string response, out int code)
    {
        TimeSpan timeout = TimeSpan.FromMilliseconds(GetTimeout());
        UriBuilder uriBuilder = new UriBuilder(apiUrl);

        var requestMessage = BuildMessage(HttpMethod.Put, uriBuilder.Uri, requestBody, bearerToken, contentType);
        var requestTask = PerformRequest(requestMessage, timeout);
        var httpResponse = requestTask.Result;

        (response, code) = (httpResponse.Payload, httpResponse.Code);
    }
}
