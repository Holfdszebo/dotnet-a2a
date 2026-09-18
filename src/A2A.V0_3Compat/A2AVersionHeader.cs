namespace A2A.V0_3Compat;

internal static class A2AVersionHeader
{
    internal const string V03 = "0.3";
    internal const string V10 = "1.0";

    internal static string? Normalize(string? version)
    {
        if (string.IsNullOrWhiteSpace(version))
        {
            return null;
        }

        return version.Trim();
    }

    internal static bool IsSupported(string? normalizedVersion) =>
        normalizedVersion is null or V03 or V10;
}
