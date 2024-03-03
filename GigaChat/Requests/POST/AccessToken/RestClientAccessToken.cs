using GigaChat.Repository;
using RestSharp;

namespace GigaChat.Requests.POST.AccessToken;

public class RestClientAccessToken: RestClientGigaChat
{
    public RestClientAccessToken(string token, string scope): base(_restClientOptions)
    {
        this.AddDefaultHeader("RqUID", $"{Guid.NewGuid()}");
        this.AddDefaultHeader("Authorization", $"Basic {token}");
        this.AddDefaultParameter("scope", $"{scope}");
    }
}