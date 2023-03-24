namespace testBlazor.Data.services
{
    /// <summary>
    /// Интерфейс сервиса работы с заявками
    /// </summary>
    public interface IRequestService
    {
        List<Request> getRequestsByClientId(Guid id);

        bool insertRequest(Request request);

        bool deleteRequestById(Guid id);

        bool updateRequestById(Guid id, Request request);

        public Request getSingleRequestById(Guid id);

        public int? getHighestRequestNumber();
    

    }
}
