var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEyeMedServices(builder.Configuration);
builder.Services.AddVspServices(builder.Configuration);

builder.Services.AddApplicationServices();

builder.Services.AddRestApiExtensions();

var app = builder.Build();

app.UseRestApiExtensions();

app.Run();
