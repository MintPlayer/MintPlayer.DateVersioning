namespace MintPlayer.DateVersioning.Code;

internal static class EntryPoint
{
    public static Task<string> GetFormattedDateAsync()
    {
        return Task.FromResult(DateTime.Now.ToString("yyyy.M.5"));
    }
}
