using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Infrastructure.Persistence.Builders
{
    /// <summary>
    /// A builder class for constructing a <see cref="Product"/> object.
    /// It follows the Builder pattern to create a product instance step by step.
    /// </summary>
    internal class ProductBuilder
    {
        private Product _product;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductBuilder"/> with the id.
        /// </summary>
        /// <param name="id">Product's unique identifier</param>
        public ProductBuilder(Guid id)
        {
            _product = new Product() { Id = id };
        }

        /// <summary>
        /// Sets the product's name.
        /// </summary>
        /// <param name="article">The article of the product.</param>
        /// <returns>The current <see cref="ProductBuilder"/> instance</returns>
        public ProductBuilder WithName(string name)
        {
            _product.Name = name;
            return this;
        }

        /// <summary>
        /// Sets the product's article number.
        /// </summary>
        /// <param name="article">The article of the product.</param>
        /// <returns>The current <see cref="ProductBuilder"/> instance</returns>
        public ProductBuilder WithArticle(string article)
        {
            _product.Article = article;
            return this;
        }

        /// <summary>
        /// Sets the product's description.
        /// </summary>
        /// <param name="description">The description of the product.</param>
        /// <returns>The current <see cref="ProductBuilder"/> instance</returns>
        public ProductBuilder WithDescription(string description)
        {
            _product.Description = description;
            return this;
        }

        /// <summary>
        /// Sets the product's price.
        /// </summary>
        /// <param name="price">The price of the product.</param>
        /// <returns>The current <see cref="ProductBuilder"/> instance.</returns>
        public ProductBuilder WithPrice(float price)
        {
            _product.Price = price;
            return this;
        }

        /// <summary>
        /// Sets the product's quantity in stock.
        /// </summary>
        /// <param name="quantity">The quantity of the product in stock.</param>
        /// <returns>The current <see cref="ProductBuilder"/>.</returns>
        public ProductBuilder WithQuantityInStock(int quantity)
        {
            _product.QuantityInStock = quantity;
            return this;
        }

        /// <summary>
        /// Returns the fully constructed <see cref="Product"/> object.
        /// </summary>
        /// <returns>The final <see cref="Product"/> object.</returns>
        public Product Build()
        {
            return _product;
        }
    }
}
