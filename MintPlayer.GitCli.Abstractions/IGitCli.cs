namespace MintPlayer.GitCli.Abstractions;

public interface IGitCli
{
    Task<IGitCliResult> Run(string args, string workingDirectory);
}