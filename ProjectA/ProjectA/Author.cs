namespace LibraryDomain
{
    public class Author : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
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
