using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Zengenti.Contensis.Delivery;
using RazorPageLeifExample.Models;

namespace RazorPageLeifExample.Pages;

public class BlogModel : PageModel
{
    private readonly ILogger<BlogModel> _logger;

    public BlogModel(ILogger<BlogModel> logger)
    {
        _logger = logger;
    }
   public BlogPost BlogPostModel { get; set; }

    public void OnGet()
    {
        // Connect to the Contensis delivery API
        var client = ContensisClient.Create();

        // Get the id from the querystring
        string BlogId = HttpContext.Request.Query["id"];

        // Get the entries by the id
        BlogPostModel = client.Entries.Get<BlogPost>(BlogId);

        // Set the page title to the blog title
        ViewData["Title"] = BlogPostModel.Title;
    }


}

