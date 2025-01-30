using MediatR;
using RepositoryService.Application.Interfaces;
using RepositoryService.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoryService.Application.Behaviors
{
    public class UnitOfWorkBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommandRequest
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
