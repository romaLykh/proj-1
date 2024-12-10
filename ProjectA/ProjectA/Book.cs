namespace LibraryDomain
{
    public class Book : BaseEntity, ICloneable
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void AssignCategory(Category category)
        {
            Category = category;
        }

        public object Clone()
        {
            return new Book
            {
                Title = Title,
                Author = Author,
                Publisher = Publisher,
                Category = Category,
                Orders = new List<Order>(Orders)
            };
        }
    }
}
