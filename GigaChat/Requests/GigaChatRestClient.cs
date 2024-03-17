using RestSharp;

namespace GigaChat.Requests
{
    public class GigaChatRestClient : RestClient
    {
        public static RestClientOptions generateRestClientOptions(string baseUrl)
        {
            return new(baseUrl)
            {
                MaxTimeout = -1,
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true,
            };
        }

        public GigaChatRestClient(string baseUrl) : base(generateRestClientOptions(baseUrl))
        {
        }
    }
}