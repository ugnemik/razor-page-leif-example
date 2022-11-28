using Zengenti.Contensis.Delivery;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddRazorPagesOptions(
        (options) =>
        {
            // Override root to always render blog listing
            options.Conventions.AddPageRoute("/Blog/BlogPost", "/");
            // Use a parameterised route template to render a blog post
            options.Conventions.AddPageRoute("/Blog/BlogPost", "/blog/{slug}");
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseHttpLogging();
app.UseStatusCodePagesWithReExecute("/Error");
app.MapRazorPages();

// Contensis client connection details
ContensisClient.Configure(
    new ContensisClientConfiguration(
        rootUrl: "https://api-leif.cloud.contensis.com",
        projectApiId: "website",
        clientId: "2f3165ff-7841-4e7d-83c6-79770275bbe1",
        sharedSecret: "23df7fdd8744496c91a9a3fd7d7cf16f-4908e4643eda4d6989f07f806ead697b-447133b6b55d4767a5a0bb47cebb87a2"
    )
);

app.Run();