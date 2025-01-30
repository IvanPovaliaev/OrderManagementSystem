using InventoryService.Domain.Models;
using System;

namespace InventoryService.Infrastructure.Persistence.Builders
{
    /// <summary>
    /// A builder class for constructing a <see cref="Order"/> object.
    /// It follows the Builder pattern to create a order instance step by step.
    /// </summary>
    internal class OrderBuilder
    {
        private Order _order;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderBuilder"/> with the id and creation date.
        /// </summary>
        /// <param name="id">Order's unique identifier</param>
        /// <param name="creationDate">Order's creation date</param>
        public OrderBuilder(Guid id, DateTime creationDate)
        {
            _order = new Order() { Id = id, CreationDate = creationDate };
        }

        /// <summary>
        /// Sets the order's store until date.
        /// </summary>
        /// <param name="storeUntil">The storeUntil date of the order.</param>
        /// <returns>The current <see cref="OrderBuilder"/> instance</returns>
        public OrderBuilder WithStoreUntil(DateTime storeUntil)
        {
            _order.StoreUntil = storeUntil;
            return this;
        }

        /// <summary>
        /// Sets the order's status.
        /// </summary>
        /// <param name="status">The status of the order.</param>
        /// <returns>The current <see cref="OrderBuilder"/> instance</returns>
        public OrderBuilder WithStatus(OrderStatus status)
        {
            _order.Status = status;
            return this;
        }

        /// <summary>
        /// Sets the order's client full name.
        /// </summary>
        /// <param name="clientFullName">The client full name.</param>
        /// <returns>The current <see cref="OrderBuilder"/> instance</returns>
        public OrderBuilder WithClientFullName(string clientFullName)
        {
            _order.ClientFullName = clientFullName;
            return this;
        }

        /// <summary>
        /// Sets the order's client phone.
        /// </summary>
        /// <param name="clientPhone">The client phone.</param>
        /// <returns>The current <see cref="OrderBuilder"/> instance.</returns>
        public OrderBuilder WithClientPhone(string clientPhone)
        {
            _order.ClientPhone = clientPhone;
            return this;
        }

        /// <summary>
        /// Sets the order's items count.
        /// </summary>
        /// <param name="totalItemsCount">The count of the items in current order.</param>
        /// <returns>The current <see cref="OrderBuilder"/></returns>
        public OrderBuilder WithTotalItemsCount(int totalItemsCount)
        {
            _order.TotalItems = totalItemsCount;
            return this;
        }

        /// <summary>
        /// Sets the order's total price.
        /// </summary>
        /// <param name="totalPrice">The total price of current order.</param>
        /// <returns>The current <see cref="OrderBuilder"/></returns>
        public OrderBuilder WithTotalPrice(decimal totalPrice)
        {
            _order.TotalPrice = totalPrice;
            return this;
        }

        /// <summary>
        /// Returns the fully constructed <see cref="Order"/> object.
        /// </summary>
        /// <returns>The final <see cref="Order"/> object.</returns>
        public Order Build()
        {
            return _order;
        }
    }
}
