using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using commercetools.Sdk.Client;

namespace MultiClientsDemo.Application
{
    /// <summary>
    /// Provide IClient based on Client Name
    /// </summary>
    public class ClientProviderFactory : IClientProviderFactory
    {
        private readonly IEnumerable<IClient> _clients;
        public string ClientName { get; set; } //you can set it with default client name

        public ClientProviderFactory(IEnumerable<IClient> clients)
        {
            if (clients == null || !clients.Any())
            {
                throw new ArgumentNullException(nameof(clients));
            }
            _clients = clients;
        }

        //
        public IClient Create()
        {
            if(string.IsNullOrEmpty(ClientName))
            {
                throw new Exception("ClientName can't be null");
            }
            //get client by clientName
            var client = _clients.FirstOrDefault(c => c.Name == ClientName);
            if(client==null)
            {
                throw new Exception($"can't find client with name {ClientName}");
            }
            return client;
        }
    }
}
