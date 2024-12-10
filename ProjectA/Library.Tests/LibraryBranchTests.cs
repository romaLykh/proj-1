using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class LibraryBranchTests
{
    private LibraryBranch _libraryBranch;
    private Book _book;

    [TestInitialize]
    public void Setup()
    {
        _libraryBranch = new LibraryBranch { Name = "Main Branch", Location = "123 Library St." };
        _book = new Book { Title = "Test Book" };
    }

    [TestMethod]
    public void AddBook_ShouldAddBookToLibraryBranch()
    {
        // Act
        _libraryBranch.AddBook(_book);

        // Assert
        Assert.IsTrue(_libraryBranch.AvailableBooks.Contains(_book));
    }

    [TestMethod]
    public void AddBook_ShouldNotAddDuplicateBookToLibraryBranch()
    {
        // Arrange
        _libraryBranch.AddBook(_book);

        // Act
        _libraryBranch.AddBook(_book);

        // Assert
        Assert.AreEqual(1, _libraryBranch.AvailableBooks.Count(b => b == _book));
    }

    [TestMethod]
    public void RemoveBook_ShouldReturnTrue_WhenBookIsRemoved()
    {
        // Arrange
        _libraryBranch.AddBook(_book);

        // Act
        var result = _libraryBranch.RemoveBook(_book);

        // Assert
        Assert.IsTrue(result);
        Assert.IsFalse(_libraryBranch.AvailableBooks.Contains(_book));
    }

    [TestMethod]
    public void RemoveBook_ShouldReturnFalse_WhenBookIsNotInLibraryBranch()
    {
        // Act
        var result = _libraryBranch.RemoveBook(_book);

        // Assert
        Assert.IsFalse(result);
    }
}

