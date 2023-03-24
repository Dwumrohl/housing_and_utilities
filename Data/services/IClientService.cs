namespace testBlazor.Data.services
{
    public interface IClientService
    {
        List<Client> GetClients();

        bool insertClient(Client client);

        bool deleteClient(Guid id);

        bool updateClient(Guid id, Client client);

        bool updateClientByEmail(string email, Client client);

        Task<Client> SingleClient(string email);

        public Client getSingleClientByEmail(string email);
    }
}





