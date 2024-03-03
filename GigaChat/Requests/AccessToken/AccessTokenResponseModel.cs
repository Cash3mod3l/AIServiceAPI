namespace GigaChat.Requests.AccessToken
{
    public class AccessTokenResponseModel
    {
        public string access_token { get; set; } = null!;
        public long expires_at { get; set; }
    }
}