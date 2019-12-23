﻿using Optivem.Framework.Core.Common.Http;
using Optivem.Template.Core.Application.Products.Requests;
using Optivem.Template.Core.Application.Products.Responses;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IProductHttpService : IHttpService
    {
        Task<IObjectClientResponse<BrowseProductsResponse>> BrowseProductsAsync(BrowseProductsRequest request);

        Task<IObjectClientResponse<ProductResponse>> CreateProductAsync(CreateProductRequest request);

        Task<IObjectClientResponse<FindProductResponse>> FindProductAsync(FindProductRequest request);

        Task<IObjectClientResponse<ListProductsResponse>> ListProductsAsync(ListProductRequest request);

        Task<IObjectClientResponse<ProductResponse>> RelistProductAsync(RelistProductRequest request);

        Task<IObjectClientResponse<ProductResponse>> UnlistProductAsync(UnlistProductRequest request);

        Task<IObjectClientResponse<ProductResponse>> UpdateProductAsync(UpdateProductRequest request);
    }
}