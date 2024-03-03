using GigaChat.Requests.AccessToken;
using Xunit.Abstractions;

namespace Tests.GigaChat.Tests.Requests.POST;

public class AccessTokenTests
{
    private readonly ITestOutputHelper _outputHelper;
    private AccessTokenRestClient _accessTokenRestClient;

    public AccessTokenTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;

        _accessTokenRestClient =
            new AccessTokenRestClient(
                "ZTBhZGYxY2EtNTUxZC00ZWZkLWI0ZWMtY2ZkMWMzODQyMTQyOmNmMzkyYThmLTUzZjMtNDJiMC05MmU3LTAyNzc4NTY4YmRhYQ==",
                "GIGACHAT_API_PERS");
        
    }

    [Fact]
    public async Task DisplayTest()
    {
        AccessTokenRequest accessToken = new AccessTokenRequest(_accessTokenRestClient);

        var response = await accessToken.Send();
        
        if (response is not null)
        {
            _outputHelper.WriteLine(response.access_token);
            _outputHelper.WriteLine(response.expires_at.ToString());
        }
    }
}