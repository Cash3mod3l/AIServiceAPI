using RestSharp;

namespace GigaChat.Requests.POST.AccessToken;

public class AccessToken
{
    private RestRequest _restRequest;
    private RestClientAccessToken _restClientAccessToken;

    public AccessToken(RestClientAccessToken restClientAccessToken)
    {
        _restClientAccessToken = restClientAccessToken;
        
        _restRequest = new RestRequest("v2/oauth");
        _restRequest.AddHeader("Accept", "application/json");
        _restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
    }

    public async Task<RestResponse> SendAccessToken()
    {
        var response = await _restClientAccessToken.PostAsync(_restRequest);

        return response;
    }
}