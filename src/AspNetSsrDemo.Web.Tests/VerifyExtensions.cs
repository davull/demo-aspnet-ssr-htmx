using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace AspNetSsrDemo.Web.Tests;

public static class VerifyExtensions
{
    public static INodeList ScrubLinks(this INodeList nodes)
    {
        nodes.QuerySelectorAll("head > link")
            .Cast<IHtmlLinkElement>()
            .ToList()
            .ForEach(l => l.Href = PrepareSrc(l.Href));

        return nodes;
    }

    public static INodeList ScrubScripts(this INodeList nodes)
    {
        nodes.QuerySelectorAll("body > script")
            .Cast<IHtmlScriptElement>()
            .ToList()
            .ForEach(s => s.Source = PrepareSrc(s.Source));

        return nodes;
    }

    public static INodeList ScrubAntiForgeryTokens(this INodeList nodes)
    {
        nodes.QuerySelectorAll("input[name='__RequestVerificationToken']")
            .Cast<IHtmlInputElement>()
            .ToList()
            .ForEach(i => { i.SetAttribute("value", "[VerificationToken]"); });

        return nodes;
    }

    private static string? PrepareSrc(string? src)
    {
        if (string.IsNullOrEmpty(src))
        {
            return src;
        }

        if (src.Contains('?'))
        {
            src = src[..src.IndexOf('?')];
        }

        if (src.StartsWith("about://", StringComparison.Ordinal))
        {
            src = src["about://".Length..];
        }

        return src;
    }
}