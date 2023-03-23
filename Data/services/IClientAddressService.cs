namespace testBlazor.Data.services
{
    public interface IClientAddressService
    {
        List<ClientAddress> GetClientAddress(long id);

        bool insertClientAddress(ClientAddress address);

        bool deleteClientAddress(long id);

        bool updateClientAddress(long id, ClientAddress address);

        public ClientAddress getSingleClientAddressById(long id);
    }
}
