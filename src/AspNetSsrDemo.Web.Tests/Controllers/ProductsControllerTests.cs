using System.Net;
using FluentAssertions;

namespace AspNetSsrDemo.Web.Tests.Controllers;

public class ProductsControllerTests : IntegrationTestBase
{
    [Theory]
    [TestCase("/products")]
    [TestCase("/products/index")]
    public async Task Page_Should_Return_Ok(string path)
    {
        var response = await GetAsync(path);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Index_Response_ShouldMatchSnapshot()
    {
        var response = await GetAsync("/products");
        await Verify(response);
    }

    [Test]
    public async Task Index_Content_ShouldMatchSnapshot()
    {
        var html = await GetString("/products");
        await VerifyHtml(html);
    }

    [Test]
    public async Task Details_WoId_ShouldReturnNotFound()
    {
        var response = await GetAsync("/products/details");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Details_WithUnknownId_ShouldReturnNotFound()
    {
        var response = await GetAsync("/products/details/99");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Test]
    public async Task Details_WithId_ShouldReturnOk()
    {
        var response = await GetAsync("/products/details/1");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Details_Response_ShouldMatchSnapshot()
    {
        var response = await GetAsync("/products/details/1");
        await Verify(response);
    }

    [Test]
    public async Task Details_Content_ShouldMatchSnapshot()
    {
        var html = await GetString("/products/details/1?edit=false");
        await VerifyHtml(html);
    }
    
    [Test]
    public async Task Details_Edit_WithId_ShouldReturnOk()
    {
        var response = await GetAsync("/products/details/1?edit=true");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Test]
    public async Task Details_Edit_Content_ShouldMatchSnapshot()
    {
        var html = await GetString("/products/details/1?edit=true");
        await VerifyHtml(html);
    }
}