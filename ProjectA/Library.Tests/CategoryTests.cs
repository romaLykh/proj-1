using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class CategoryTests
{
    private Category _category;
    private Book _book;

    [TestInitialize]
    public void Setup()
    {
        _category = new Category { Name = "Test Category" };
        _book = new Book { Title = "Test Book" };
    }

    [TestMethod]
    public void AddBook_ShouldAddBookToCategory()
    {
        // Act
        _category.AddBook(_book);

        // Assert
        Assert.IsTrue(_category.Books.Contains(_book));
    }

    [TestMethod]
    public void RemoveBook_ShouldReturnTrue_WhenBookIsRemoved()
    {
        // Arrange
        _category.Books.Add(_book);

        // Act
        var result = _category.RemoveBook(_book);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(_category.Books.Contains(_book));
    }
}
