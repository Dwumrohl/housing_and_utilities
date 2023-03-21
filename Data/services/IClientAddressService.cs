namespace testBlazor.Data.services
{
    public interface IClientAddressService
    {
        List<ClientAddress> GetClientAddress(long id);
        void insertClientAddress(ClientAddress address);
        void deleteClientAddress(long id);
        void updateClientAddress(long id, ClientAddress address);
        public ClientAddress getSingleClientAddressById(long id);
    }
}
