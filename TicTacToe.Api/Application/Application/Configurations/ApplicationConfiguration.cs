using Microsoft.Extensions.Configuration;

namespace Application.Configurations;

public static class ApplicationConfiguration
{
    private static readonly IConfigurationRoot Config = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json").Build();

    public static readonly string JwtToken = Config
        .GetSection("ReallySecret")
        .GetSection("JwtSecToken")
        .Get<string>();
}