﻿using RepositoryService.Application.Interfaces;
using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Application.Orders.Commands.ChangeOrderStatus
{
    /// <summary>
    /// Represents a command to change the status of an order.
    /// </summary>
    /// <param name="Id">The unique identifier of the order</param>
    /// <param name="NewStatus">The new status to be assigned to the order</param>
    public record class ChangeOrderStatusCommand(Guid Id, OrderStatus NewStatus) : ICommandRequest;
}
