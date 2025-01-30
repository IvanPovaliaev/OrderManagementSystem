using MediatR;

namespace RepositoryService.Application.Interfaces
{
    /// <summary>
    /// Represents a command request without a response.
    /// </summary>
    public interface ICommandRequest : IRequest;

    /// <summary>
    /// Represents a command request with a response.
    /// </summary>
    /// <typeparam name="TResponse">The type of response returned by the request.</typeparam>
    public interface ICommandRequest<TResponse> : IRequest<TResponse>;
}
