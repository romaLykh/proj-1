namespace LibraryDomain
{

    public class Order : BaseEntity
    {
        public Reader Reader { get; set; }
        public Book Book { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }


        public void ApproveOrder()
        {
            Status = OrderStatus.Completed;
        }

        public void CancelOrder()
        {
            Status = OrderStatus.Canceled;
        }
    }
}
