using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class ReaderTests
{
    private Reader _reader;
    private Book _book;
    private Order _order;

    [TestInitialize]
    public void Setup()
    {
        _reader = new Reader { FullName = "John Doe" };
        _book = new Book { Title = "Test Book" };
        _order = new Order { Id = Random.Shared.Next(300), Book = _book, Reader = _reader, OrderDate = DateTime.Now, Status = OrderStatus.Pending };
    }

    [TestMethod]
    public void CreateOrder_ShouldReturnNewOrder()
    {
        // Act
        var order = _reader.CreateOrder(_book);

        // Assert
        Assert.IsNotNull(order);
        Assert.AreEqual(_book, order.Book);
        Assert.AreEqual(_reader, order.Reader);
    }

    [TestMethod]
    public void CancelOrder_ShouldReturnTrue_WhenOrderIsCanceled()
    {
        // Arrange
        var createdOrder = _reader.CreateOrder(_book);

        // Act
        var result = _reader.CancelOrder(createdOrder);

        // Assert
        Assert.IsTrue(result);
    }
}
