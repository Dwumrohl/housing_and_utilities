namespace testBlazor.Data.services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
        /// <summary>
        /// Добавление клиента
        /// </summary>
        /// <param name="client">Клиент</param>
        void insertClient(Client client);
        void deleteClient(long id);
        void updateClient(long id, Client client);
        void updateClientByEmail(string email, Client client);
        Task<Client> SingleClient(string email);
        Task<bool> UpdateTest(Client client);
        public Client getSingleClientByEmail(string email);
    }
}





