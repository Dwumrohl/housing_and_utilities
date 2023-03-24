namespace testBlazor.Data.services
{
    public interface IClientAddressService
    {
        List<ClientAddress> GetClientAddress(Guid id);

        bool insertClientAddress(ClientAddress address);

        bool deleteClientAddress(Guid id);

        bool updateClientAddress(Guid id, ClientAddress address);

        public ClientAddress getSingleClientAddressById(Guid id);
    }
}
