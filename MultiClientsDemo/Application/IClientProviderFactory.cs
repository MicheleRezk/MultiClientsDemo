using commercetools.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiClientsDemo.Application
{
    public interface IClientProviderFactory
    {
        string ClientName { get; set; }
        IClient Create();
    }
}
