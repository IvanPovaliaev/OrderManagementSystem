using MediatR;
using RepositoryService.Application.Models;
using System;

namespace RepositoryService.Application.Orders.Queries.GetOrderById
{
    public record class GetOrderByIdQuery(Guid Id) : IRequest<OrderDetailsDTO?>;
}
