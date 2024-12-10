namespace LibraryDomain
{
    public class Reader : BaseEntity
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Order CreateOrder(Book book)
        {
            throw new NotImplementedException();
        }

        public bool CancelOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
