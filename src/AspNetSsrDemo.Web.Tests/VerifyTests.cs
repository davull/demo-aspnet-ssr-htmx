namespace AspNetSsrDemo.Web.Tests;

public class VerifyTests
{
    [Test]
    public async Task Run()
    {
        await VerifyChecks.Run();
    }
}