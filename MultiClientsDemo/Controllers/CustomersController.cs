using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercetools.Sdk.Client;
using commercetools.Sdk.Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using MultiClientsDemo.Application;

namespace MultiClientsDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IClient _client;

        public CustomersController(IClientProviderFactory clientProviderFactory)
        {
            this._client = clientProviderFactory.Create();
        }

        // GET api/customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryCustomersCommand = new QueryCommand<Customer>();
            var returnedSet = await _client.ExecuteAsync(queryCustomersCommand);
            return Ok(returnedSet.Results);
        }
    }
}
