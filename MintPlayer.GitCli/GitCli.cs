using Microsoft.Extensions.Logging;
using MintPlayer.GitCli.Abstractions;
using System.ComponentModel;
using System.Diagnostics;

namespace MintPlayer.GitCli;

internal class GitCli : IGitCli
{
    #region Constructor
    private readonly ILogger logger;
    public GitCli(ILogger logger)
    {
        this.logger = logger;
    }
    #endregion

    public async Task<IGitCliResult> Run(string args, string workingDirectory)
    {
        using var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = args,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            },
            EnableRaisingEvents = true,
        };

        try
        {
            var tcs = new TaskCompletionSource<object>();
            process.Exited += (_, _) => tcs.SetResult(0);

            process.Start();
            var result = await tcs.Task;

            var standardOutput = await process.StandardOutput.ReadToEndAsync();
            var standardError = await process.StandardError.ReadToEndAsync();
            var exitCode = process.ExitCode;

            return new GitCliResult
            {
                Status = exitCode == 0,
                Output = standardOutput,
            };
        }
        catch (Win32Exception ex)
        {
            throw new InvalidOperationException("\"git\" is not present in PATH.", ex);
        }
    }
}