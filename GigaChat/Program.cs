using GigaChat.Configs;
using GigaChat.Managers;
using GigaChat.Requests;
using GigaChat.Requests.AccessToken;

var builder = WebApplication.CreateBuilder(args);

GigaChatConfig config = builder.Configuration.GetSection("GigaChatConfig").Get<GigaChatConfig>() ?? throw new ArgumentNullException("Не удалось найти конфиг");

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AccessTokenManager>(
    (provider) =>
    {
        AccessTokenRestClient accessTokenRestClient = new
        (
            config.AccessTokenUrl,
            config.ClientToken,
            GigaChatScopeTools.Of(config.AccessTokenScope)
        );
        AccessTokenManager accessTokenManager = new(accessTokenRestClient);

        return accessTokenManager;
    }
);

builder.Services.AddSingleton<GigaChatRestClient>(
    (provider) =>
        {
            return new GigaChatRestClient(config.BaseUrl);
        }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
