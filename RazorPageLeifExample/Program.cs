using Zengenti.Contensis.Delivery;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error");

app.MapRazorPages();
// Contensis client connection details
ContensisClient.Configure(new ContensisClientConfiguration(
    rootUrl: "https://cms-zenhub.cloud.contensis.com",
    projectApiId: "leif",
    clientId: "ff258f73-0872-4e75-8f9f-7f6e4471808e",
    sharedSecret: "78b47d9e88954d499dd3c0ca78c7db6e-f1c38cd758454e16b417cccb538ef3ba-8115cc35afa44bf0b458b9260e553f37"
));

app.Run();
