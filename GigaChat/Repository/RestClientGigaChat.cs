using RestSharp;

namespace GigaChat.Repository;

public abstract class RestClientGigaChat : RestClient
{
    protected static RestClientOptions _restClientOptions = new RestClientOptions("https://ngw.devices.sberbank.ru:9443/api") {
        MaxTimeout = -1,
        RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
    };

    public RestClientGigaChat(RestClientOptions restClientOptions) : base(restClientOptions)
    {
        _restClientOptions = restClientOptions;
    }
}