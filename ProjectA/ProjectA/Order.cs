namespace LibraryDomain
{

    public class Order : BaseEntity
    {

        public event EventHandler<int> OrderCanceled;
        public event EventHandler<int> OrderApproved;

        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            Status = OrderStatus.Pending;
            OrderDate = DateTime.Now;
        }

        public void ApproveOrder()
        {
            Status = OrderStatus.Completed;
            OrderApproved?.Invoke(this, Id);
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Canceled;
            OrderCanceled?.Invoke(this, Id);
        }
    }
}
