namespace testBlazor.Data
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        void insertClient(Client client);
        void deleteClient(long id);
        void updateClient(long id, Client client);
        Client SingleClient(long id);

    }
}





