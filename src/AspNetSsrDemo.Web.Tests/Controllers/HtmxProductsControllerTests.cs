using System.Net;
using FluentAssertions;

namespace AspNetSsrDemo.Web.Tests.Controllers;

public class HtmxProductsControllerTests : IntegrationTestBase
{
    [Theory]
    [TestCase("/htmxproducts")]
    [TestCase("/htmxproducts/index")]
    public async Task Page_Should_Return_Ok(string path)
    {
        var response = await GetAsync(path);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Test]
    public async Task Index_Response_ShouldMatchSnapshot()
    {
        var response = await GetAsync("/htmxproducts");
        await Verify(response);
    }

    [Test]
    public async Task Index_Content_ShouldMatchSnapshot()
    {
        var html = await GetString("/htmxproducts");
        await VerifyHtml(html);
    }
}