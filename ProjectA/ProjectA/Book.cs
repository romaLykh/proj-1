namespace LibraryDomain
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public void UpdateTitle(string newTitle)
        {
            throw new NotImplementedException();
        }

        public void AssignCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
