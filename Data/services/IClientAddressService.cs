namespace testBlazor.Data.services
{
    public interface IClientAddressService
    {
        IEnumerable<ClientAddress> GetClientAddress();
        void insertClientAddress(ClientAddress address);
        void deleteClientAddress(long id);
        void updateClientAddress(long id, ClientAddress address);
        public ClientAddress getSingleClientAddressById(long id);
    }
}
