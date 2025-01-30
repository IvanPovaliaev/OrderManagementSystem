using InventoryService.Application.Interfaces;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Behaviors
{
    /// <summary>
    /// Represents a behavior that manages the Unit of Work for command requests.
    /// </summary>
    /// <remarks>
    /// This behavior ensures that changes are saved to the database only if the Unit of Work is enabled.
    /// </remarks>
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandRequest
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Handles the request by managing the Unit of Work's save changes behavior.
        /// </summary>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var canBeSaved = _unitOfWork.CanSaveChanges();
            if (canBeSaved)
            {
                _unitOfWork.DisableSaveChanges();
            }

            var response = await next();

            if (canBeSaved)
            {
                _unitOfWork.EnableSaveChanges();
                await _unitOfWork.SaveChangesAsync();
            }

            return response;
        }
    }
}
