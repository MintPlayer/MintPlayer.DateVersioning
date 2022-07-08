using Microsoft.Extensions.DependencyInjection;
using MintPlayer.GitCli.Abstractions;
using MintPlayer.GitCli.Extensions;

namespace MintPlayer.DateVersioning.Code;

internal static class EntryPoint
{
    public static string GetFormattedDate()
    {
        //var services = new ServiceCollection()
        //    .AddGitCli()
        //    .BuildServiceProvider();

        //var gitCli = services.GetRequiredService<IGitCli>();
        //var commits = gitCli.Run()

        return DateTime.Now.ToString("yyyy.M.5");
    }
}
