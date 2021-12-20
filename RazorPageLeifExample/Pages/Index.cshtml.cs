using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zengenti.Contensis.Delivery;
using Zengenti.Search;
using RazorPageLeifExample.Models;
using Zengenti.Data;

namespace RazorPageLeifExample.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    public PagedList<BlogPost> BlogsPayload { get; set; }
    public void OnGet()
    {
        ViewData["Title"] = "Blogs";

        // Connect to the Contensis delivery API
        var client = ContensisClient.Create();

        // Query the api for entries with a content type of "blogPost"
        // Get the latest versions even if not yet published
        var blogsQuery = new Query(
            Op.EqualTo("sys.contentTypeId", "blogPost"),
            Op.EqualTo("sys.versionStatus", "latest")
        );

        // Get a list of entries matching the blogsQuery
        BlogsPayload = client.Entries.Search<BlogPost>(blogsQuery);
    }
}
