using System.Net;
using System.Text.Json;
using RestSharp;

namespace GigaChat.Requests.AccessToken;
public class AccessTokenRequest : IRequest<AccessTokenResponseModel>
{
    private RestRequest _restRequest;
    private AccessTokenRestClient _accessTokenRestClient;

    public AccessTokenRequest(AccessTokenRestClient accessTokenRestClient)
    {
        _accessTokenRestClient = accessTokenRestClient;
        
        _restRequest = new RestRequest("oauth", Method.Post);
        _restRequest.AddHeader("Accept", "application/json");
        _restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
    }

    public async Task<AccessTokenResponseModel?> Send()
    {
        var response = await _accessTokenRestClient.ExecuteAsync(_restRequest);

        if (response is null || response.StatusCode != HttpStatusCode.OK || response.Content is null)
        {
            return null;
        }

        return JsonSerializer.Deserialize<AccessTokenResponseModel>(response.Content);
    }
}