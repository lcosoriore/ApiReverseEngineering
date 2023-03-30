using ApiReverseEngineering.Data;
using ApiReverseEngineering.Interfaces;
using ApiReverseEngineering.Models;

namespace ApiReverseEngineering.Services
{
    public class ClientServices : IClient
    {
        private readonly ApisContext apisContext;

        public ClientServices(ApisContext apisContext)
        {
            this.apisContext = apisContext;
        }
        public IEnumerable<Client> Get()
        {
            return apisContext.Clients;
        }

        public async Task Save(ClientRequestModel client)
        {
            try
            {
                Client clientModel = new Client();
                clientModel.ClientId = Guid.NewGuid();
                clientModel.Name = client.Name;
                clientModel.Email = client.Email;
                apisContext.Add(clientModel);
                await this.apisContext.SaveChangesAsync();

            }
            catch (Exception e)
            {

                Console.WriteLine($"Error en insercion: {e.Message}  + inner {e.InnerException}");
            }
            
        }

        public async Task Update(Guid id, Client clients)
        {
            var currentClient = apisContext.Clients.Find(id);
            if (currentClient != null)
            {
                currentClient.Name = clients.Name;
                currentClient.Email = clients.Email;
                await apisContext.SaveChangesAsync();
            }

        }

        public async Task Delete(Guid id)
        {
            var currentClient = apisContext.Clients.Find(id);
            if (currentClient != null)
            {
                apisContext.Remove(currentClient);
                await apisContext.SaveChangesAsync();
            }

        }

    }
}
