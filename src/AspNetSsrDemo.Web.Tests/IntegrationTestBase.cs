using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Testing;
using VerifyTests.AngleSharp;

namespace AspNetSsrDemo.Web.Tests;

public abstract class IntegrationTestBase : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory = new();

    public void Dispose()
    {
        _factory.Dispose();
        GC.SuppressFinalize(this);
    }

    protected HttpClient CreateClient()
    {
        var options = new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        };
        return _factory.CreateClient(options);
    }

    protected async Task<HttpResponseMessage> GetAsync(string url)
    {
        using var client = CreateClient();
        return await client.GetAsync(url);
    }

    protected async Task<string> GetString(string url)
    {
        using var response = await GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }

    protected static async Task VerifyHtml(string html, [CallerFilePath] string sourceFile = "")
    {
        await Verify(html, "html", sourceFile: sourceFile).PrettyPrintHtml(nodes =>
        {
            nodes.ScrubAttributes(x => x.Name.StartsWith("b-", StringComparison.Ordinal));
            nodes.ScrubLinks()
                .ScrubScripts()
                .ScrubAntiForgeryTokens();
        });
    }
}