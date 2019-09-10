﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Application.Mappers;
using Optivem.Framework.Core.Application.UseCases;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Orders.Requests;
using Optivem.Template.Core.Application.Orders.Responses;
using Optivem.Template.Core.Domain.Orders;

namespace Optivem.Template.Core.Application.Orders.UseCases
{
    public class ArchiveOrderUseCase : ExecuteAggregateUseCase<IOrderRepository, ArchiveOrderRequest, ArchiveOrderResponse, Order, OrderIdentity, int>
    {
        public ArchiveOrderUseCase(IUseCaseMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }

        protected override void Execute(ArchiveOrderRequest request, Order aggregateRoot)
        {
            aggregateRoot.Archive();
        }
    }
}
