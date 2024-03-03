using RestSharp;

namespace GigaChat.Requests;

public abstract class GigaChatRestClient : RestClient
{
    public static RestClientOptions generateRestClientOptions(string url)
    {
        return new(url) {
            MaxTimeout = -1,
            RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
        };
    }

    public GigaChatRestClient() : base(generateRestClientOptions("https://gigachat.devices.sberbank.ru/api/v1")) {}
}