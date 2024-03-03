using GigaChat.Requests;
using RestSharp;

namespace GigaChat.Requests.AccessToken;

public class AccessTokenRestClient: RestClient
{
    public AccessTokenRestClient(string token, string scope) : base(GigaChatRestClient.generateRestClientOptions("https://ngw.devices.sberbank.ru:9443/api/v2"))
    {
        this.AddDefaultHeader("RqUID", $"{Guid.NewGuid()}");
        this.AddDefaultHeader("Authorization", $"Basic {token}");
        this.AddDefaultParameter("scope", $"{scope}");
    }
}