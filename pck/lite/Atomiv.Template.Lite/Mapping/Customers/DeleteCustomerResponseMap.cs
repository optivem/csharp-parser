﻿using Atomiv.Template.Lite.Dtos.Customers;
using Atomiv.Template.Lite.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atomiv.Template.Lite.Mapping.Customers
{
	public class DeleteCustomerResponseMap : Profile
	{
		public DeleteCustomerResponseMap()
		{
			CreateMap<Customer, DeleteCustomerResponse>();
		}
	}
}
