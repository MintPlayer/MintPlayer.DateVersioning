using MintPlayer.GitCli.Abstractions;

namespace MintPlayer.GitCli;

internal class GitCliResult : IGitCliResult
{
    public bool Status { get; init; }
    public string Output { get; init; } = string.Empty;
}
