using GigaChat.Requests.POST.AccessToken;
using Xunit.Abstractions;

namespace Tests.GigaChat.Tests.Requests.POST;

public class AccessTokenTests
{
    private readonly ITestOutputHelper _outputHelper;
    private RestClientAccessToken _restClientAccessToken;

    public AccessTokenTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;

        _restClientAccessToken =
            new RestClientAccessToken(
                "ZTBhZGYxY2EtNTUxZC00ZWZkLWI0ZWMtY2ZkMWMzODQyMTQyOjk2MGQzMzY2LWYwODMtNDViZS1hZWEwLWY3Nzc1MTRmYmI5Mw==",
                "GIGACHAT_API_PERS");
        
    }

    [Fact]
    public async Task DisplayTest()
    {
        AccessToken accessToken = new AccessToken(_restClientAccessToken);

        var response = await accessToken.SendAccessToken();
        
        _outputHelper.WriteLine(response.ResponseStatus.ToString());
        _outputHelper.WriteLine(response.ErrorException?.ToString() ?? "");
        _outputHelper.WriteLine(response.Content);
    }
}