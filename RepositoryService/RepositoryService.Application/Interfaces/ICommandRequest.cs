using MediatR;

namespace RepositoryService.Application.Interfaces
{
    public interface ICommandRequest : IRequest;
    public interface ICommandRequest<TResponse> : IRequest<TResponse>;
}
