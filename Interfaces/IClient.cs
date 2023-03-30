using ApiReverseEngineering.Models;

namespace ApiReverseEngineering.Interfaces
{
    public interface IClient
    {
        IEnumerable<Client> Get();
        Task Save(ClientRequestModel client);
        Task Update(Guid id, Client client);
        Task Delete(Guid id);
    }
}
