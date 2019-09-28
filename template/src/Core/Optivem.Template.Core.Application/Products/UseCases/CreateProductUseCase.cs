﻿using Optivem.Framework.Core.Application;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using Optivem.Template.Core.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products.UseCases
{
    public class CreateProductUseCase : CreateAggregateUseCase<IProductRepository, CreateProductRequest, CreateProductResponse, Product, ProductIdentity, int>
    {
        public CreateProductUseCase(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }
    }
}