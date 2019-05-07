﻿using Optivem.Core.Application.Mappers;
using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;
using Optivem.Core.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Core.Application.UseCases
{
    class FindAllUseCase<TRequest, TResponse, TRecordResponse, TEntity, TId> : IFindAllUseCase<TRequest, TResponse>
        where TRequest : IFindAllRequest
        where TResponse : IFindAllResponse<TRecordResponse>, new()
        where TRecordResponse : IFindAllRecordResponse
        where TEntity : class, IEntity<TId>
    {
        public FindAllUseCase(IResponseMapper responseMapper, IReadonlyRepository<TEntity, TId> repository)
        {
            ResponseMapper = responseMapper;
            Repository = repository;
        }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IReadonlyRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            // TODO: VC: Later handling use case with pagination, need corresponding dto and also result not just list

            var entities = await Repository.GetAsync();
            var records = ResponseMapper.MapEnumerable<TEntity, TRecordResponse>(entities).ToList();

            return new TResponse
            {
                Data = records,
            };
        }
    }
}