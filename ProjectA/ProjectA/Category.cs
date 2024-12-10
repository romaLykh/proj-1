namespace LibraryDomain
{
public class Category : BaseEntity, INamedEntity, IComparable<Category>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public bool RemoveBook(Book book)
        {
            return Books.Remove(book);
        }

        public int CompareTo(Category other)
        {
            if (other == null) return 1;
            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }
}
