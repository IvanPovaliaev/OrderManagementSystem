using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IProductsRepository ProductsRepository { get; }
        public IOrdersRepository OrdersRepository { get; }
        private bool _canSaveChanges = true;

        public UnitOfWork(DatabaseContext databaseContext, IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            _databaseContext = databaseContext;
            ProductsRepository = productsRepository;
            OrdersRepository = ordersRepository;
        }

        public async Task SaveChangesAsync()
        {
            if (!_canSaveChanges)
            {
                return;
            }
            await _databaseContext.SaveChangesAsync();
        }

        public void EnableSaveChanges()
        {
            _canSaveChanges = true;
        }

        public void DisableSaveChanges()
        {
            _canSaveChanges = false;
        }

        public bool CanSaveChanges()
        {
            return _canSaveChanges;
        }
    }
}
