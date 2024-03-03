using GigaChat.Managers;
using GigaChat.Requests;
using GigaChat.Requests.AccessToken;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
builder.Services.AddSingleton<GigaChatRestClient>();
builder.Services.AddSingleton<AccessTokenRestClient>();

builder.Services.AddSingleton<AccessTokenManager>();
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.Run();
