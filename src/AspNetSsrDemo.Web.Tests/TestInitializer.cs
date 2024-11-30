using System.Globalization;
using System.Runtime.CompilerServices;

namespace AspNetSsrDemo.Web.Tests;

internal static class TestInitializer
{
    [ModuleInitializer]
    internal static void Run()
    {
        VerifyAngleSharpDiffing.Initialize();

        var culture = CultureInfo.GetCultureInfo("en-US");
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}