using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class AuthorTests
{
    private Author _author;
    private Book _book;

    [TestInitialize]
    public void Setup()
    {
        _author = new Author { Name = "Test Author" };
        _book = new Book { Title = "Test Book" };
    }

    [TestMethod]
    public void AddBook_ShouldAddBookToAuthor()
    {
        // Act
        _author.AddBook(_book);

        // Assert
        Assert.IsTrue(_author.Books.Contains(_book));
    }

    [TestMethod]
    public void RemoveBook_ShouldReturnTrue_WhenBookIsRemoved()
    {
        // Arrange
        _author.Books.Add(_book);

        // Act
        var result = _author.RemoveBook(_book);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(_author.Books.Contains(_book));
    }
}
