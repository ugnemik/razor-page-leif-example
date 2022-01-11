# Using Contensis with .NET Razor Pages

This step by step guide will take you through getting your entries from Contensis and displaying them using the delivery API and a simple Node.js app.

## Requirements

* [Git](https://git-scm.com/downloads)
* Command line interface knowledge

### Visual Studio

* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/#download) with the ASP.NET and web development workload.

### VS Code

* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

## Using the demo project

This app will pull in data from the Leif project in Contensis. The Razor Pages demo is used so you can see how a simple app can use the delivery API.

To get started:

* Clone the Contensis Razor Pages project *** Make sure we update the example here ***

```shell
git clone https://path-to-the-project-in-github
```

* Change directory to RazorPageLeifExample

```shell
cd RazorPageLeifExample
```

* Run with hot reloading

```shell
dotnet watch
```

The Razor Pages example will open up in your browser.

## How it works

### Include the Contensis delivery API helper

The Contensis delivery API helper contains classes to perform the repetitive tasks of retrieving content from the API.

Include an instance of ```Zengenti.Contensis.Delivery```:

```c#
using Zengenti.Contensis.Delivery;
```

### Set the connection details

```c#
ContensisClient.Configure(new ContensisClientConfiguration(
    rootUrl: "<root-url>",
    projectApiId: "<projectApiId>",
    clientId: "clientId",
    sharedSecret: "<sharedSecret>"
));
```

### Connect to the Contensis Delivery API

```c#
var client = ContensisClient.Create();
```

### Create a class for each Content Type

E.g. the Blog Content Type:

```c#
// Models/BlogPost.cs
using Zengenti.Contensis.Delivery;

namespace RazorPageLeifExample.Models {
    public class BlogPost: EntryModel {
        public string Title { get; set; } = null!;
        public string? LeadParagraph { get; set; }
        public Image? ThumbnailImage { get; set; }
        public Person? Author => Resolve<Person>("author");
        public Category? Category => Resolve<Category>("category");
        public ComposedField? PostBody { get; set; }
    }
}
```



### Get a single blog entry by its id

Pass this class to `client.Entries.Get` to return a strongly typed `BlogPost`.

```c#
// Pages/Blog.cshtml.cs
// Set the model
public BlogPost? BlogPostModel { get; set; }

public void OnGet()
{
    // Connect to the Contensis delivery API
    // Connection details set in /Program.cs
    var client = ContensisClient.Create();

    // Get the id from the querystring
    string BlogId = HttpContext.Request.Query["id"];

    // Get the entries by the id
    BlogPostModel = client.Entries.Get<BlogPost>(BlogId);
}
```

### Use the model in the view

```html
<!-- Pages/Blog.cshtml -->
<div class="blog-hero">
  <h1 class="blog-hero__title">
    @Model.BlogPostModel.Title
  </h1>
  @if(Model.BlogPostModel.ThumbnailImage != null) {
    <img class="blog-hero__img" src="@("http://live.leif.zenhub.contensis.cloud" + Model.BlogPostModel.ThumbnailImage.Asset.Uri)" alt="@Model.BlogPostModel.ThumbnailImage.AltText"/>
  }
</div>
```
