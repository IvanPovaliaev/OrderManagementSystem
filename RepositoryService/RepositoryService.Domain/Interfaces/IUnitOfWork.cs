using System.Threading.Tasks;

namespace RepositoryService.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductsRepository ProductsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }

        public Task SaveChangesAsync();

        public void EnableSaveChanges();
        public void DisableSaveChanges();
        public bool CanSaveChanges();
    }
}
