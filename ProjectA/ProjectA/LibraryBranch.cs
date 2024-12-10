namespace LibraryDomain
{
    public class LibraryBranch : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Book> AvailableBooks { get; set; } = new List<Book>();

        public void AddBook(Book book)
        {
            if (book != null && !AvailableBooks.Contains(book))
            {
                AvailableBooks.Add(book);
            }
        }

        public bool RemoveBook(Book book)
        {
            return AvailableBooks.Remove(book);
        }
    }
}
