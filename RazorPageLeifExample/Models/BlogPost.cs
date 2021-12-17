using Zengenti.Contensis.Delivery;

namespace RazorPageLeifExample.Models {
    public class BlogPost: EntryModel {
        public string? Title { get; set; }
        public string? LeadParagraph { get; set; }
        public Image? ThumbnailImage { get; set; }
        public Person? Author { get; set; }
        public ComposedField? PostBody { get; set; }
    }

    public class Person: EntryModel  {
        public string? Name { get; set; }
        public Image? Photo { get; set; }
    }
}
