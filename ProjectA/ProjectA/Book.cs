namespace LibraryDomain
{
    public class Book : BaseEntity, ICloneable
    {

        public string Title { get; set; }
        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public Category Category { get; set; }

        public void UpdateTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void ChangeCategory(Category category)
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
            };
        }
    }
}
