using LibraryDomain;

namespace Library.Tests;

[TestClass]
public sealed class CategoryTests
{
    private Category _category1;
    private Category _category2;

    [TestInitialize]
    public void Setup()
    {
        _category1 = new Category { Name = "Category A" };
        _category2 = new Category { Name = "Category B" };
    }

    [TestMethod]
    public void CompareTo_ShouldReturnNegative_WhenFirstCategoryIsLessThanSecond()
    {
        // Act
        var result = _category1.CompareTo(_category2);

        // Assert
        Assert.IsTrue(result < 0);
    }

    [TestMethod]
    public void CompareTo_ShouldReturnPositive_WhenFirstCategoryIsGreaterThanSecond()
    {
        // Act
        var result = _category2.CompareTo(_category1);

        // Assert
        Assert.IsTrue(result > 0);
    }

    [TestMethod]
    public void CompareTo_ShouldReturnZero_WhenCategoriesAreEqual()
    {
        // Arrange
        var category3 = new Category { Name = "Category A" };

        // Act
        var result = _category1.CompareTo(category3);

        // Assert
        Assert.AreEqual(0, result);
    }
}
