﻿using Atomiv.Infrastructure.SequentialGuid;
using Atomiv.Template.Core.Domain.Orders;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.IdentityGenerators
{
    public class OrderIdentityGenerator : GuidIdentityGenerator<OrderIdentity>
    {
        protected override OrderIdentity Create(Guid value)
        {
            return new OrderIdentity(value);
        }
    }
}
