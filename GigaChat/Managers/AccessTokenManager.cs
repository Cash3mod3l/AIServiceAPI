using GigaChat.Requests.AccessToken;

namespace GigaChat.Managers
{
    public class AccessTokenManager
    {
        private readonly AccessTokenRestClient _accessTokenRestClient;

        private string _accessToken;
        private DateTime _TTL;

        public string AccessToken
        {
            get
            {
                if (_TTL <= DateTime.Now)
                {
                    (_accessToken, _TTL) = generateAccessToken();
                }

                return _accessToken;
            }
        }

        public AccessTokenManager(AccessTokenRestClient accessTokenRestClient)
        {
            _accessTokenRestClient = accessTokenRestClient;
            (_accessToken, _TTL) = generateAccessToken();
        }

        private (string accessToken, DateTime TTL) generateAccessToken()
        {
            AccessTokenRequest accessTokenRequest = new(_accessTokenRestClient);
            AccessTokenResponseModel response = accessTokenRequest.Send().GetAwaiter().GetResult() ?? throw new IOException("Не удалось получить токен авторизации");

            return
            (
                response.access_token,
                DateTimeOffset.FromUnixTimeSeconds(response.expires_at).UtcDateTime
            );
        }
    }
}