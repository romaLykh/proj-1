using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class OrderTests
{
    private Order _order;

    [TestInitialize]
    public void Setup()
    {
        _order = new Order { Status = OrderStatus.Pending };
    }

    [TestMethod]
    public void ApproveOrder_ShouldChangeStatusToCompleted()
    {
        // Act
        _order.ApproveOrder();

        // Assert
        Assert.AreEqual(OrderStatus.Completed, _order.Status);
    }

    [TestMethod]
    public void CancelOrder_ShouldChangeStatusToCanceled()
    {
        // Act
        _order.CancelOrder();

        // Assert
        Assert.AreEqual(OrderStatus.Canceled, _order.Status);
    }
}
