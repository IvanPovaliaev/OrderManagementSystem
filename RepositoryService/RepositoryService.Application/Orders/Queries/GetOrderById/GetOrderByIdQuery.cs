using MediatR;
using RepositoryService.Application.Models;
using System;

namespace RepositoryService.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<OrderDetailsDTO?>
    {
        public Guid Id { get; init; }
    }
}
