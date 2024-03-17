using GigaChat.Managers;
using GigaChat.Requests.ChatCompletions.Models;
using RestSharp;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace GigaChat.Requests.ChatCompletions
{
    public class ChatCompletionsRequest
    {
        private GigaChatRestClient _gigaChatRestClient;
        private AccessTokenManager _accessTokenManager;
        private RestRequest _restRequest;

        private readonly JsonSerializerOptions optionsSerialize = new()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public ChatCompletionsRequest(GigaChatRestClient gigaChatRestClient, AccessTokenManager accessTokenManager, ChatContext chatContext)
        {
            _gigaChatRestClient = gigaChatRestClient;
            _accessTokenManager = accessTokenManager;

            _restRequest = new RestRequest("chat/completions", Method.Post);
            _restRequest.AddHeader("Content-Type", "application/json");
            _restRequest.AddHeader("Accept", "application/json");

            ChatCompletionsRequestBody objRequestBody = new()
            {
                    messages = chatContext,
            };
            string jsonRequestBody = JsonSerializer.Serialize(objRequestBody, optionsSerialize);
            _restRequest.AddStringBody(jsonRequestBody, DataFormat.Json);
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