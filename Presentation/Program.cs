var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEyeMedHttpClient(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddRestApiExtensions();

var app = builder.Build();

app.UseRestApiExtensions();

app.Run();
