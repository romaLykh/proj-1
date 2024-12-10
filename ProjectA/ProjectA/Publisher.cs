namespace LibraryDomain
{
    public class Publisher : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        public bool RemoveBook(Book book)
        {
            return Books.Remove(book);
        }
    }
}
