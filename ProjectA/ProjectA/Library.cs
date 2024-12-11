namespace LibraryDomain
{
    public class Library : BaseEntity, INamedEntity
    {
        public event EventHandler<Book> BookAdded;

        public List<Book> AvailableBooks { get; set; } = new List<Book>();
        public string Name { get; set; }

        public void AddBook(Book book)
        {
            if (book != null && !AvailableBooks.Contains(book))
            {
                AvailableBooks.Add(book);
                BookAdded?.Invoke(this, book);
            }
        }

        public bool RemoveBook(Book book)
        {
            return AvailableBooks.Remove(book);
        }
    }
}
