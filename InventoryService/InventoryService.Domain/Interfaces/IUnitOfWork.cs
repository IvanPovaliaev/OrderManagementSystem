using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces
{
    /// <summary>
    /// Defines the Unit of Work pattern for managing repositories.
    /// </summary>
    public interface IUnitOfWork
    {
        public IProductsRepository ProductsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }

        /// <summary>
        /// Saves all changes asynchronously.
        /// </summary>
        public Task SaveChangesAsync();

        /// <summary>
        /// Enables saving changes.
        /// </summary>
        public void EnableSaveChanges();

        /// <summary>
        /// Disables saving changes.
        /// </summary>
        public void DisableSaveChanges();

        /// <summary>
        /// Determines whether changes can be saved.
        /// </summary>
        /// <returns>True if changes can be saved, otherwise false.</returns>
        public bool CanSaveChanges();
    }
}
