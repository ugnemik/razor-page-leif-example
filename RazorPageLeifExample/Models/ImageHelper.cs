using Zengenti.Contensis.Delivery;

namespace RazorPageLeifExample.Models;

public static class ImageHelper
{
    public static string? GetImageUrl(Image? image)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            return "https://staging-leif.cloud.contensis.com" + image?.Asset?.Uri;
        }
        return image?.Asset?.Uri;
    }
}