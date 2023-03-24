namespace testBlazor.Data.services
{
    /// <summary>
    /// Интерфейс сервиса работы с заявками
    /// </summary>
    public interface IRequestService
    {
        List<Request> getRequestsByClientId(Guid id);

        bool insertClientAddress(Request request);

        bool deleteRequestById(Guid id);

        bool updateRequestById(Guid id, ClientAddress request);

        public Request getSingleRequestById(Guid id);

    }
}
