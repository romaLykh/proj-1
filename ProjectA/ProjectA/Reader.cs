namespace LibraryDomain
{
    public class Reader : BaseEntity
    {
        public string FullName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Order CreateOrder(Book book)
        {

            var order = new Order
            {
                Id = Random.Shared.Next(300),
                Reader = this,
                Book = book,
                OrderDate = DateTime.Now,
                Status = OrderStatus.Pending,
            };

            Orders.Add(order);
            return order;
        }

        public bool CancelOrder(Order order)
        {

            if (Orders.Contains(order))
            {
                var orderToCancel = Orders.Find(o => o.Id == order.Id);
                orderToCancel.CancelOrder();

                return true;
            }
            return false;
        }
    }
}
