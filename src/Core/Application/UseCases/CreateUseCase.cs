﻿using Optivem.Core.Application.Mappers;
using Optivem.Core.Application.Requests;
using Optivem.Core.Application.Responses;
using Optivem.Core.Domain.Entities;
using Optivem.Core.Domain.Repositories;
using Optivem.Core.Domain.UnitOfWork;
using System.Threading.Tasks;

namespace Optivem.Core.Application.UseCases
{
    public class CreateUseCase<TRequest, TResponse, TEntity, TId> : ICreateUseCase<TRequest, TResponse>
        where TRequest : ICreateRequest
        where TResponse : ICreateResponse<TId>
        where TEntity: class, IEntity<TId>
    {
        public CreateUseCase(IRequestMapper requestMapper, IResponseMapper responseMapper, IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository)
        {
            RequestMapper = requestMapper;
            ResponseMapper = responseMapper;
            UnitOfWork = unitOfWork;
            Repository = repository;
        }

        protected IRequestMapper RequestMapper { get; private set; }

        protected IResponseMapper ResponseMapper { get; private set; }

        protected IUnitOfWork UnitOfWork { get; private set; }

        protected IRepository<TEntity, TId> Repository { get; private set; }

        public async Task<TResponse> HandleAsync(TRequest request)
        {
            var entity = RequestMapper.Map<TRequest, TEntity>(request);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            var response = ResponseMapper.Map<TEntity, TResponse>(entity);
            return response;
        }
    }
}