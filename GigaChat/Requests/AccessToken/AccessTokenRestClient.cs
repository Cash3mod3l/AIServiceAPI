using GigaChat.Requests;
using RestSharp;

namespace GigaChat.Requests.AccessToken
{
    public enum GigaChatScope
    {
        Personal,
        Corporate
    }
    public static class GigaChatScopeTools
    {
        public static Dictionary<GigaChatScope, string> GigaChatScopeNames = new()
        {
            {GigaChatScope.Personal, "GIGACHAT_API_PERS"},
            {GigaChatScope.Corporate, "GIGACHAT_API_CORP"}
        };

        public static string ToString(this GigaChatScope scope)
        {
            return GigaChatScopeNames[scope];
        }

        public static GigaChatScope Of(string scope)
        {
            return GigaChatScopeNames.FirstOrDefault(x => x.Value == scope).Key;
        }
    }
    


    public class AccessTokenRestClient: RestClient
    {
        public AccessTokenRestClient(string token, GigaChatScope scope) : base(GigaChatRestClient.generateRestClientOptions("https://ngw.devices.sberbank.ru:9443/api/v2"))
        {
            this.AddDefaultHeader("RqUID", $"{Guid.NewGuid()}");
            this.AddDefaultHeader("Authorization", $"Basic {token}");
            this.AddDefaultParameter("scope", $"{scope}");
        }
    }
}