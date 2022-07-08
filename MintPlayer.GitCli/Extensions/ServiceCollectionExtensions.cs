using Microsoft.Extensions.DependencyInjection;
using MintPlayer.GitCli.Abstractions;

namespace MintPlayer.GitCli.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGitCli(this IServiceCollection services)
    {
        return services.AddScoped<IGitCli, GitCli>();
    }
}
