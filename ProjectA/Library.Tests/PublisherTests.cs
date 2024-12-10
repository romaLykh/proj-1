using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class PublisherTests
{
    private Publisher _publisher;
    private Book _book;

    [TestInitialize]
    public void Setup()
    {
        _publisher = new Publisher { Name = "Test Publisher" };
        _book = new Book { Title = "Test Book" };
    }

    [TestMethod]
    public void AddBook_ShouldAddBookToPublisher()
    {
        // Act
        _publisher.AddBook(_book);

        // Assert
        Assert.IsTrue(_publisher.Books.Contains(_book));
    }

    [TestMethod]
    public void RemoveBook_ShouldReturnTrue_WhenBookIsRemoved()
    {
        // Arrange
        _publisher.Books.Add(_book);

        // Act
        var result = _publisher.RemoveBook(_book);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(_publisher.Books.Contains(_book));
    }
}
