﻿using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Web.AspNetCore;
using Optivem.Template.Core.Application.Customers;
using Optivem.Template.Core.Application.Customers.Commands;
using Optivem.Template.Core.Application.Customers.Queries;
using System;
using System.Threading.Tasks;

namespace Optivem.Template.Web.RestApi.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : BaseController<ICustomerApplicationService>
    {
        public CustomerController(ICustomerApplicationService service)
            : base(service)
        {
        }

        [HttpGet(Name = "list-customers")]
        [ProducesResponseType(typeof(ListCustomersQueryResponse), 200)]
        public async Task<ActionResult<ListCustomersQueryResponse>> ListCustomersAsync()
        {
            var request = new ListCustomersQuery();
            var response = await Service.ListCustomersAsync(request);
            return Ok(response);
        }

        [HttpGet("{id}", Name = "find-customer")]
        [ProducesResponseType(typeof(FindCustomerQueryResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<FindCustomerQueryResponse>> FindCustomerAsync(Guid id)
        {
            var request = new FindCustomerQuery
            {
                Id = id,
            };

            var response = await Service.FindCustomerAsync(request);
            return Ok(response);
        }

        [HttpPost(Name = "create-customer")]
        [ProducesResponseType(typeof(DeleteCustomerCommandResponse), 201)]
        public async Task<ActionResult<DeleteCustomerCommandResponse>> CreateCustomerAsync(CreateCustomerCommand request)
        {
            var response = await Service.CreateCustomerAsync(request);
            return CreatedAtRoute("find-customer", new { id = response.Id }, response);
        }

        [HttpPut("{id}", Name = "update-customer")]
        [ProducesResponseType(typeof(DeleteCustomerCommandResponse), 201)]
        public async Task<ActionResult<DeleteCustomerCommandResponse>> UpdateCustomerAsync(Guid id, UpdateCustomerCommand request)
        {
            var response = await Service.UpdateCustomerAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "delete-customer")]
        public async Task<ActionResult> DeleteCustomerAsync(Guid id)
        {
            var request = new DeleteCustomerCommand
            {
                Id = id,
            };

            await Service.DeleteCustomerAsync(request);
            return NoContent();
        }
    }
}