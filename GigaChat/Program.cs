using GigaChat.Managers;
using GigaChat.Requests;
using GigaChat.Requests.AccessToken;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Services.AddSingleton<GigaChatRestClient>();
builder.Services.AddSingleton<AccessTokenRestClient>();

builder.Services.AddSingleton<AccessTokenManager>();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
