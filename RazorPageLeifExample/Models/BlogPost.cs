using Zengenti.Contensis.Delivery;

namespace RazorPageLeifExample.Models
{
    public class BlogPost : EntryModel
    {
        public string Title { get; set; } = null!;
        public string? LeadParagraph { get; set; }
        public Image? PrimaryImage { get; set; }
        public string? PrimaryImageUrl => ImageHelper.GetImageUrl(PrimaryImage);
        public Person? Author => Resolve<Person>("author");
        public Category? Category => Resolve<Category>("category");
        public ComposedField? PostBody { get; set; }
    }
}
