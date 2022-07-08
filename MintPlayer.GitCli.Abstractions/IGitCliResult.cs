namespace MintPlayer.GitCli.Abstractions;

public interface IGitCliResult
{
    public bool Status { get; init; }
    public string Output { get; init; }
}
