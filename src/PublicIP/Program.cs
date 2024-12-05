using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication
    .CreateSlimBuilder(args);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

app.MapGet("/", (HttpContext context) => context.Connection.RemoteIpAddress?.ToString() ?? string.Empty);

await app.RunAsync();
