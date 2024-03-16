using GigaChat.Managers;
using GigaChat.Models;
using RestSharp;
using System.Net;
using System.Text.Json;

namespace GigaChat.Requests.ChatCompletions
{
    public class ChatCompletionsRequest
    {
        private GigaChatRestClient _gigaChatRestClient;
        private AccessTokenManager _accessTokenManager;
        private RestRequest _restRequest;

        public ChatCompletionsRequest(GigaChatRestClient gigaChatRestClient, AccessTokenManager accessTokenManager, ChatContext chatContext)
        {
            _gigaChatRestClient = gigaChatRestClient;
            _accessTokenManager = accessTokenManager;

            _restRequest = new RestRequest("oauth", Method.Post);
            _restRequest.AddHeader("Accept", "application/json");
            _restRequest.AddHeader("Content-Type", "application/json");

            _restRequest.RequestFormat = DataFormat.Json;
            _restRequest.AddJsonBody
            (
                new ChatCompletionsRequestBodyModel()
                {
                    messages = chatContext
                }
            );
        }

        public async Task<string?> Send()
        {
            _restRequest.AddHeader("Authorization", $"Bearer {_accessTokenManager.AccessToken}");
            var response = await _gigaChatRestClient.ExecuteAsync(_restRequest);

            if (response is null || response.StatusCode != HttpStatusCode.OK || response.Content is null)
            {
                return null;
            }

            return JsonDocument.Parse(response.Content).RootElement
                .GetProperty("choices")
                [0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();
        }
    }
}