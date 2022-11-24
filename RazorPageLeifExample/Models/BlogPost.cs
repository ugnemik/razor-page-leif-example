using Zengenti.Contensis.Delivery;

namespace RazorPageLeifExample.Models {
    public class BlogPost: EntryModel {
        public string Title { get; set; } = null!;
        public string? LeadParagraph { get; set; }
        public Image? ThumbnailImage { get; set; }
        public string? ThumbnailImageUrl => ImageHelper.GetImageUrl(ThumbnailImage);
        public Person? Author => Resolve<Person>("author");
        public Category? Category => Resolve<Category>("category");
        public ComposedField? PostBody { get; set; }
    }
}
