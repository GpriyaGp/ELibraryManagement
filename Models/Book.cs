namespace ELibraryManagement.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int ISDN { get; set; }
        public int Version { get; set; }
        public int Year { get; set; }

        public int Quantity { get; set; }
    }
}
