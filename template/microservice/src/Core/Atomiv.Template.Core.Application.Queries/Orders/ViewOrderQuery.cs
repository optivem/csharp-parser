﻿using Atomiv.Core.Application;

namespace Atomiv.Template.Core.Application.Queries.Orders
{
    public class ViewOrderQuery : IRequest<ViewOrderQueryResponse>
    {
        public string Id { get; set; }
    }
}