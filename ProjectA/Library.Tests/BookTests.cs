using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class BookTests
{
    private Book _book;
    private Category _category;

    [TestInitialize]
    public void Setup()
    {
        _book = new Book { Title = "Test Book" };
        _category = new Category { Name = "Test Category" };
    }

    [TestMethod]
    public void UpdateTitle_ShouldChangeBookTitle()
    {
        // Act
        _book.UpdateTitle("New Title");

        // Assert
        Assert.AreEqual("New Title", _book.Title);
    }

    [TestMethod]
    public void AssignCategory_ShouldChangeBookCategory()
    {
        // Act
        _book.ChangeCategory(_category);

        // Assert
        Assert.AreEqual(_category, _book.Category);
    }

    [TestMethod]
    public void Clone_ShouldReturnExactCopyOfBook()
    {
        // Act
        var clonedBook = (Book)_book.Clone();

        // Assert
        Assert.AreEqual(_book.Title, clonedBook.Title);
        Assert.AreEqual(_book.Author, clonedBook.Author);
        Assert.AreEqual(_book.Publisher, clonedBook.Publisher);
        Assert.AreEqual(_book.Category, clonedBook.Category);
    }
}
