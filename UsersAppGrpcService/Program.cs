using UsersAppGrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<UserRandomAPIService>();
app.MapGet("/", () => "Hello!");

app.Run();
