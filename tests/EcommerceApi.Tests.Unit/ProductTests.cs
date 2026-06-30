using Xunit;
using FluentAssertions;
using EcommerceApi.Domain.Entities;

namespace EcommerceApi.Tests.Unit.Domain;

public class ProductTests
{
    [Fact]
    public void UpdatePrice_WithValidPrice_UpdatesSuccessfully()
    {
        // Arrange
        var product = new Product 
        { 
            Id = 1, 
            Name = "Test Product",
            Price = 100m,
            StockQuantity = 10
        };

        // Act
        product.UpdatePrice(150m);

        // Assert
        product.Price.Should().Be(150m);
        product.UpdatedAt.Should().NotBeNull();
    }

    [Fact]
    public void UpdatePrice_WithInvalidPrice_ThrowsException()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test", Price = 100m };

        // Act & Assert
        product.Invoking(p => p.UpdatePrice(-50m))
            .Should()
            .Throw<ArgumentException>();
    }

    [Fact]
    public void ReduceStock_WithSufficientStock_DecreasesSuccessfully()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test", StockQuantity = 10 };

        // Act
        product.ReduceStock(5);

        // Assert
        product.StockQuantity.Should().Be(5);
    }

    [Fact]
    public void ReduceStock_WithInsufficientStock_ThrowsException()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test", StockQuantity = 3 };

        // Act & Assert
        product.Invoking(p => p.ReduceStock(5))
            .Should()
            .Throw<InvalidOperationException>()
            .WithMessage("Insufficient stock");
    }

    [Fact]
    public void AddStock_IncreasesStockQuantity()
    {
        // Arrange
        var product = new Product { Id = 1, Name = "Test", StockQuantity = 10 };

        // Act
        product.AddStock(20);

        // Assert
        product.StockQuantity.Should().Be(30);
    }
}
