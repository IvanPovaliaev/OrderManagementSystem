using MediatR;

namespace RepositoryService.Application.Interfaces
{
    public interface IQueryRequest<TResponse> : IRequest<TResponse>;
}
