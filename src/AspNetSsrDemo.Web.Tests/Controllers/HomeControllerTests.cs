using System.Net;
using FluentAssertions;

namespace AspNetSsrDemo.Web.Tests.Controllers;

public class HomeControllerTests : IntegrationTestBase
{
    [Theory]
    [TestCase("/")]
    [TestCase("/home")]
    [TestCase("/home/index")]
    [TestCase("/home/privacy")]
    public async Task Home_Should_Return_Ok(string path)
    {
        var response = await GetAsync(path);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task NotExisting_Url_Should_Return_NotFound()
    {
        var response = await GetAsync("/unknown");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Home_Response_ShouldMatchSnapshot()
    {
        var response = await GetAsync("/home");
        await Verify(response);
    }

    [Test]
    public async Task Home_Content_ShouldMatchSnapshot()
    {
        var html = await GetString("/home");
        await VerifyHtml(html);
    }
}